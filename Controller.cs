﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;

namespace WorkSpaceCashier
{
    class Controller
    {
        private string workingFolder;
        private List<string> resultText;

        public string WorkingFolder { get => workingFolder; set => workingFolder = value; }
        public List<string> ResultText { get => resultText; set => resultText = value; }

        public async Task Post_SignIn_Cashier_CheckBoxAPI()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ListStaticVar.URI_BaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "cashier.json"));

            StringContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_SigningCashier, httpContent);

            var result = await response.Content.ReadAsStringAsync();
            CashierResponse Json_Array = JsonConvert.DeserializeObject<CashierResponse>(result);
            ResultText = new List<string>(); 
            if (response.IsSuccessStatusCode)
            {
                ResultText.Add(String.Format("Запрос выполнен успешно. Статус {0}\n", response.StatusCode));
                ResultText.Add(String.Format("Тип: {0}\n", Json_Array.type));
                ResultText.Add(String.Format("Тип токена: {0}\n", Json_Array.token_type));
                ResultText.Add(String.Format("Токен доступа: {0}\n", Json_Array.access_token));
            }
            else
            {
                resultText.Add(String.Format("Ошибка при выполнении запроса. Статус {0}", response.StatusCode));
            }

        }



        public async Task Post_OpenShift_CheckBoxAPI()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ListStaticVar.URI_BaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "auth.json"));
            Auth auth = JsonConvert.DeserializeObject<Auth>(jsonString);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);
            client.DefaultRequestHeaders.Add("X-License-Key", auth.xlicensekey);

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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ListStaticVar.URI_BaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "auth.json"));
            Auth auth = JsonConvert.DeserializeObject<Auth>(jsonString);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);
            client.DefaultRequestHeaders.Add("X-License-Key", auth.xlicensekey);

            using (HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_ShiftOpen, null))
            {
                var result = await response.Content.ReadAsStringAsync();
                string result_json = JsonConvert.SerializeObject(result);
                dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
                ResultText = new List<string>();
                if (response.IsSuccessStatusCode)
                {
                    ResultText.Add("Виконано запит на відкриття зміни\n");
                    ResultText.Add(String.Format("Статус: {0}\n", Json_Array.status));
                    ResultText.Add(String.Format("Зміна ID : {0}\n", Json_Array.id));
                    string path = Path.Combine(WorkingFolder, "shift.json");
                    File.WriteAllText(path, result_json);
                }
                else
                {
                    ResultText.Add(String.Format("Зміна вже відкрита\n", Json_Array.message));
                    ResultText.Add(String.Format("{0}\n", Json_Array.message));

                }
            }


        }

        public async Task Post_CloseShift_CheckBoxAPI()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ListStaticVar.URI_BaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var jsonString = File.ReadAllText(Path.Combine(WorkingFolder, "auth.json"));
            Auth auth = JsonConvert.DeserializeObject<Auth>(jsonString);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);
            client.DefaultRequestHeaders.Add("X-License-Key", auth.xlicensekey);

            using (HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_ShiftClose, null))
            {
                var result = await response.Content.ReadAsStringAsync();
                string result_json = JsonConvert.SerializeObject(result);
                dynamic Json_Array = JsonConvert.DeserializeObject<dynamic>(result);
                ResultText = new List<string>();
                if (response.IsSuccessStatusCode)
                {
                    ResultText.Add("Виконано запит на закриття зміни\n");
                    ResultText.Add(String.Format("Статус: {0}\n", Json_Array.status));
                    ResultText.Add(String.Format("Зміна ID : {0}\n", Json_Array.id));
                    string path = Path.Combine(WorkingFolder, "shift.json");
                    File.WriteAllText(path, result_json);
                }
                else
                {
                   // ResultText.Add(String.Format("\n", Json_Array.message));
                    ResultText.Add(String.Format("{0}\n", Json_Array.message));

                }
            }


        }

    }
}
