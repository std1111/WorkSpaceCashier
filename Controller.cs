using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace WorkSpaceCashier
{
    class Controller
    {
        private string workingFolder;
        private List<string> resultText;

        public string WorkingFolder { get => workingFolder; set => workingFolder = value; }
        public List<string> ResultText { get => resultText; set => resultText = value; }

        private HttpClient GetHttpClient(bool addAuthHeader,bool addLicenseHeader)
        {
            var client = new HttpClient();
            string uriBaseAddress = "";
            if (MainForm.testMode)
            {
                uriBaseAddress = ListStaticVar.URI_TestBaseAddress;
            }
            else
            {
                uriBaseAddress = ListStaticVar.URI_BaseAddress;
            }


            client.BaseAddress = new Uri(uriBaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (addAuthHeader)
            {
                var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "auth.json"));
                Auth auth = JsonConvert.DeserializeObject<Auth>(jsonString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);
            }

            if (addLicenseHeader)
            {
                var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "auth.json"));
                Auth auth = JsonConvert.DeserializeObject<Auth>(jsonString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);
                client.DefaultRequestHeaders.Add("X-License-Key", auth.xlicensekey);
            }

            return client;
        }

        public static string GetInfoFromJsonCheckFile(string path)
        {
            var fileCheck = File.ReadAllText(path, System.Text.Encoding.Default);

            dynamic jsonCheck = JsonConvert.DeserializeObject<dynamic>(fileCheck);
            string strInfo = String.Format("Id чека: {0}\n", jsonCheck.id);
            strInfo += String.Format("Кассир: {0}\n", jsonCheck.cashier_name);
            foreach (dynamic payment in jsonCheck.payments)
            {
                float sumCheck = (float)payment.value / 100f;
                strInfo += String.Format("Оплата: {0}: {1}  грн.\t\n", payment.type, String.Format("{0,12:0.00}", sumCheck));
            }
            strInfo += "---------------------\n";
            foreach (dynamic elem in jsonCheck.goods)
            {
                float quantity = (float)elem.quantity / 1000f;
                float price = (float)elem.good.price / 100f;
                float sum = quantity * price;
                strInfo += String.Format("{0} * {1} ={2}\t {3} \n", quantity.ToString(), String.Format("{0,12:0.00}", price), String.Format("{0,12:0.00}", sum), elem.good.name);
            }
            return strInfo;
        }




        public async Task Post_SignIn_Cashier_CheckBoxAPI()
        {
            var client = GetHttpClient(false,false);
            var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "cashier.json"));

            StringContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_SigningCashier, httpContent);

            var result = await response.Content.ReadAsStringAsync();
            CashierResponse Json_Array = JsonConvert.DeserializeObject<CashierResponse>(result);
            ResultText = new List<string>(); 
            if (response.IsSuccessStatusCode)
            {
                string pathToAuth = Path.Combine(WorkingFolder, "auth.json");
                var jsonAuth = File.ReadAllText(pathToAuth);
                Auth auth = JsonConvert.DeserializeObject<Auth>(jsonAuth);
                auth.access_token = Json_Array.access_token;
                File.WriteAllText(pathToAuth, JsonConvert.SerializeObject(auth));


                // File.WriteAllText(Path.Combine(WorkingFolder, "cashier_response.json"), JsonConvert.SerializeObject(Json_Array), Encoding.UTF8);
                ResultText.Add(string.Format("Запрос выполнен успешно. Статус {0}\n", response.StatusCode));
                ResultText.Add(string.Format("Тип: {0}\n", Json_Array.type));
                ResultText.Add(string.Format("Тип токена: {0}\n", Json_Array.token_type));
                ResultText.Add(string.Format("Токен доступа: {0}\n", Json_Array.access_token));
            }
            else
            {
                resultText.Add(String.Format("Ошибка при выполнении запроса. Статус {0}", response.StatusCode));
                //resultText.Add(String.Format("Ошибка при выполнении запроса. Статус {0}", response.StatusCode));
            }

        }



        public async Task Post_OpenShift_CheckBoxAPI()
        {
            var client = GetHttpClient(true, true);
            using (HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_ShiftOpen, null))
			{
                var result = await response.Content.ReadAsStringAsync();
				dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
				ResultText = new List<string>();
				if (response.IsSuccessStatusCode)
				{
                    ResultText.Add("Виконано запит на відкриття зміни\n");
                    ResultText.Add(String.Format("Статус: {0}\n", Json_Array.status));
                    ResultText.Add(String.Format("Зміна ID : {0}\n", Json_Array.id));
                    string path = Path.Combine(WorkingFolder, "shift.json");
                    using (StreamWriter file = File.CreateText(path))
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        Json_Array.WriteTo(writer);
                    }


                    File.WriteAllText(path, result);
				}
				else 
				{
					ResultText.Add(String.Format("Зміна вже відкрита\n", Json_Array.message));
					ResultText.Add(String.Format("{0}\n", Json_Array.message));
				}
			}
        }

        public async Task Get_InfoShift_CheckBoxAPI()
        {
            var client = GetHttpClient(true, true);
            var shiftString = File.ReadAllText(Path.Combine(WorkingFolder, "shift.json"));
            dynamic shiftJson = JsonConvert.DeserializeObject<dynamic>(shiftString);

            HttpResponseMessage response = await client.GetAsync(ListStaticVar.URI_ShiftGetInfo + shiftJson.id);
            var result = await response.Content.ReadAsStringAsync();
            string result_json = JsonConvert.SerializeObject(result);
            dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
            ResultText = new List<string>();
            if (response.IsSuccessStatusCode)
            {
                ResultText.Add("Інфо по зміні\n");
                ResultText.Add(String.Format("ID зміни: {0}\n", Json_Array.id));
                ResultText.Add(String.Format("Статус зміни: {0}\n", Json_Array.status));
                ResultText.Add(String.Format("Відкрита: {0}\n", Json_Array.opened_at));
                ResultText.Add(String.Format("Закрита: {0}\n", Json_Array.closed_at));

                string path = Path.Combine(WorkingFolder, "info_shift.json");
                File.WriteAllText(path, result);
            }
        else
        {
            ResultText.Add(String.Format("{0}\n", "Помилка отримання інформації по зміні!"));

        }
        }

        public async Task Post_CloseShift_CheckBoxAPI()
        {

            var client = GetHttpClient(true, true);
            using (HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_ShiftClose, null))
            {
                var result = await response.Content.ReadAsStringAsync();
                string result_json = JsonConvert.SerializeObject(result);
                dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
                ResultText = new List<string>();
                if (response.IsSuccessStatusCode)
                {
                    ResultText.Add("Виконано запит на закриття зміни\n");
                    ResultText.Add(String.Format("ID зміни: {0}\n", Json_Array.id));
                    ResultText.Add(String.Format("Статус зміни: {0}\n", Json_Array.status));

                    string path = Path.Combine(WorkingFolder, "shift.json");
                    File.WriteAllText(path, result);
                }
                else
                {
                    ResultText.Add(String.Format("{0}\n", Json_Array.message));

                }
            }
        }

        public async Task Get_PrintForm_CheckBoxAPI(string idReceipt, List<string> resultTxt)
        {
            var client = GetHttpClient(true, true);
            string urlReceipt = ListStaticVar.URI_Receipts + "\\" + idReceipt + "\\text";

            bool contnue = true;
            int limitSec = 30000;
            int stepSec  = 5000;
            int currSec  = 0;  
            while (contnue)
            {
                HttpResponseMessage response = await client.GetAsync(urlReceipt);
                if (response.IsSuccessStatusCode)
                {
                    Stream inputStream = await response.Content.ReadAsStreamAsync();
                    string pathToTextFile = Path.Combine(MainForm.pathFolderPrintChecks, idReceipt + ".txt");
                    using (FileStream outputFileStream = new FileStream(pathToTextFile, FileMode.Create))
                    {
                        inputStream.CopyTo(outputFileStream);
                    }
                    System.Diagnostics.Process.Start(@pathToTextFile);
                    contnue = false;
                    resultTxt.Add(String.Format("Id чека {0} \n ", idReceipt));
                    resultTxt.Add("Печатная форма чека  успешно получена и сохранена\n");
                    resultTxt.Add(String.Format("{0}\n", pathToTextFile));
                }
                else
                {
                    currSec += stepSec;
                    if (currSec > limitSec)
                    {
                        contnue = false;
                    } 

                }
            }
        }




        public async Task Post_Sell__CheckBoxAPI(string path)
        { 
            var client = GetHttpClient(true, true);
            var jsonString = File.ReadAllText(path,Encoding.Default);

            StringContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_Sell, httpContent))
		    {
                var result = await response.Content.ReadAsStringAsync();
                dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
                ResultText = new List<string>();
				if (response.IsSuccessStatusCode)
				{
                    ResultText.Add("Регистрация чека прошла успешно\n");
                    string idSell = Json_Array.id;
                    try
                    {
                        File.Copy(path, Path.Combine(MainForm.pathFolderSendChecks, Path.GetFileName(path)));
                        File.Delete(path);
                    }
                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                    Thread.Sleep(5000);
                    await Get_PrintForm_CheckBoxAPI(idSell, ResultText);
                }

                else
                {
                    ResultText.Add("Ошибка при регистрации чека\n");
                    string message = (string) Json_Array.message;
                    ResultText.Add(message);
                }
			}
        }





    }
}
