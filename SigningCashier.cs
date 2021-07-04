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
    class SigningCashier
    {
        public static async Task Post_SignIn_Cashier_CheckBoxAPI()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://dev-api.checkbox.in.ua/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-License-Key", "3e13e8648592d23a8bdac4e5");
            Cashier cashier = new Cashier();
            cashier.Login = "test2206";
            cashier.Password = "123456";
            string queryString = JsonConvert.SerializeObject(cashier);
            StringContent httpContent = new StringContent(queryString, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/api/v1/cashier/signin", httpContent);
            if (response.IsSuccessStatusCode) 
            { 
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response);
            }
            Console.Read();

        }
    }



}

