using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RatersUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpResponseMessage response = await Client.GetData("businesses");
            Task<string> values = response.Content.ReadAsStringAsync();
            Console.WriteLine(values.Result);
            //Greet();
            //Menu();
        }

        static void Greet()
        {
            Console.WriteLine("Welcome to the Raters of the Lost Business user interface!");
            // login prompts here
        }

        static void Menu()
        {
            Console.WriteLine("Would you like to:");
            Console.WriteLine("1. Look up reviews for a business.");
            Console.WriteLine("2. Write a new review.");
            Console.WriteLine("3. Update one of your old reviews.");
            Console.WriteLine("4. Delete a review.");
            Console.WriteLine("5. Logout.");
            Console.WriteLine("Please enter the number that corresponds to the menu item you would like.");
            string userInput = Console.ReadLine();

            //switch statement based on userInput variable, calling
        }

        //public async void Login()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(APIUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

        //        var response = await client.GetStringAsync(APIUrl + "businesses");
        //        string checkResult = response.ToString();
        //        Console.WriteLine(checkResult);
        //    }
        //}

        //public static async void GetData()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string APIUrl = "https://localhost:44392/";
        //        client.BaseAddress = new Uri(APIUrl);
        //        var response = await client.GetStringAsync(APIUrl + "api/Businesses");
        //        Console.WriteLine(response);
        //        string checkResult = response.ToString();
        //        Console.WriteLine(checkResult);
        //    }
        //}
        //}

        //public static async void GetThings()
        //{
        //    HttpResponseMessage response = await Client.GetData();
        //    Console.WriteLine(response + " That was it.");
        //    Task<string> values = response.Content.ReadAsStringAsync();
        //    Console.WriteLine(values);
        //}
    // methods for each api call here
    }
}
