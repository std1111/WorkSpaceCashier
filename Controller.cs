using System;
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
            //Cashier cashier = new Cashier();
            //cashier.login = "test2206";
            //cashier.password = "123456";
            Cashier cashier = new Cashier();
            using (StreamReader file = File.OpenText(Path.Combine(WorkingFolder, "cashier.json")));

            using (JsonTextReader reader = new JsonTextReader(file)) ;
            {
                cashier = (Cashier)JToken.ReadFrom(reader);
            }


            string queryString = JsonConvert.SerializeObject(cashier);
            StringContent httpContent = new StringContent(queryString, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ListStaticVar.URI_SigningCashier, httpContent);

            var result = await response.Content.ReadAsStringAsync();
            CashierResponse Json_Array = JsonConvert.DeserializeObject<CashierResponse>(result);
            ResultText = new List<string>(); 
            if (response.IsSuccessStatusCode)
            {
                ResultText.Add(String.Format("Запрос выполнен успешно. Статус {0}\n", response.StatusCode));
                ResultText.Add(String.Format("Тип {0}\n", Json_Array.type));
                ResultText.Add(String.Format("Тип токена {0}\n", Json_Array.token_type));
                ResultText.Add(String.Format("Токен доступа {0}\n", Json_Array.access_token));
            }
            else
            {
                resultText.Add(String.Format("Ошибка при выполнении запроса. Статус {0}", response.StatusCode));
            }

        }



        //public static async Task Task_Post_SignIn_Cashier_CheckBoxAPI()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://dev-api.checkbox.in.ua/");//ListStaticVar.URI_BaseAddress
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    //  client.DefaultRequestHeaders.Add("X-License-Key", "3e13e8648592d23a8bdac4e5");
        //    Cashier cashier = new Cashier()
        //    {
        //        login = "test2206",
        //        password = "123456"
        //    };

        //    string queryString = JsonConvert.SerializeObject(cashier);
        //    StringContent httpContent = new StringContent(queryString, System.Text.Encoding.UTF8, "application/json");
        //    Console.WriteLine(queryString);

        //    //HttpResponseMessage response = await client.PostAsync("api/v1/cashier/signin", httpContent);
        //    //var result = await response.Content.ReadAsStringAsync();
        //    //CashierResponse Json_Array = JsonConvert.DeserializeObject<CashierResponse>(result);
        //    try
        //    {
        //        using (HttpResponseMessage response = await client.PostAsync("/api/v1/cashier/signin", httpContent))
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            CashierResponse Json_Array = JsonConvert.DeserializeObject<CashierResponse>(result);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine(response.StatusCode);
        //                Console.WriteLine(Json_Array.access_token);
        //            }
        //            else
        //            {
        //                Console.WriteLine(response.StatusCode);
        //            }
        //        }
        //        Console.Read();
        //    }
        //    catch (HttpRequestException httpRequestException)
        //    {
        //        Console.WriteLine(httpRequestException);

        //    }
        //}
    }
}
