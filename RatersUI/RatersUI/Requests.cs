using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI
{
    public class Requests
    {
        private static string APIUrl = "https://localhost:44392/";

        public void GetData(string path)
        {
           // using (var client = new HttpClient())
          //  {
            //    client.DefaultRequestHeaders.Accept.Add("Content-Type:application/json");
              //  client.Headers.Add("Accept:application/json");
                //var result = client.DownloadString(APIUrl + path);
       //         Console.WriteLine(result);
         //   }
        }
    }
}
