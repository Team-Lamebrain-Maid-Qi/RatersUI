using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI
{
    public class Client
    {
        public static readonly HttpClient client = new();
        private static readonly string APIUrl = "https://ratersofthelostbusiness20210811140616.azurewebsites.net/api/";

        public static async Task<HttpResponseMessage> GetData(string path)
        {
            return await client.GetAsync(APIUrl + path);
        }

        public static async Task<HttpResponseMessage> GetDataWithAuthentication()
        {
            var authCredential = Encoding.UTF8.GetBytes("{User3}:{User3!}");
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authCredential));
                client.BaseAddress = new Uri(APIUrl);
                HttpResponseMessage response = await client.GetAsync(APIUrl + "users/login");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse + "RAW");
                }
                return response;
            }

        }
    }
}