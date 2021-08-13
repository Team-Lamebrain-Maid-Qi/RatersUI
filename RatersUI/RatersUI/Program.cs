using Newtonsoft.Json;
using RatersUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RatersUI
{
    class Program
    {
        private static List<BusinessDto> businesses;

        public static async Task Main(string[] args)
        {
            await Greet();
            await Menu();
        }

        static async Task Greet()
        {
            Console.WriteLine("Welcome to the Raters of the Lost Business user interface!");
            Console.WriteLine("Would you like to register an account?");
            string userInput = Console.ReadLine();
            if (userInput.Contains("y".ToLower()))
            {
                await Client.RegisterUser();
            }
        }

        static async Task Menu()
        {
            Console.WriteLine("Would you like to:");
            Console.WriteLine("1. LogIn.");
            Console.WriteLine("2. Look up reviews for a business.");
            Console.WriteLine("3. Write a new review.");
            Console.WriteLine("4. View my reviews.");
            Console.WriteLine("5. Add a new business.");
            Console.WriteLine("0. LogOut");
            Console.WriteLine("Please enter the number that corresponds to the menu item you would like.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    try
                    {
                    HttpResponseMessage logIn = await Client.Login();
                    Task<string> log = logIn.Content.ReadAsStringAsync();
                    Console.WriteLine(log.Result);
                    UserDto user = JsonConvert.DeserializeObject<UserDto>(log.Result);
                    Console.WriteLine($"Welcome {user.UserName.ToUpper()}");
                    Client.SetToken(user);
                    Client.SetId(user);
                     Client.SetReviewerId(user);
                    } catch (HttpRequestException)
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                    break;

                case "2":
                    HttpResponseMessage businessNameResponse = await Client.BusinessByName();
                    Task<string> busiResult = businessNameResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(busiResult.Result);

                    // We spent a lot of time trying to fix the post function, when we could have spent time learning how to serialize multiple objects in a JSON.

                    //string[] busiArr = busiResult.Result.Split(",{");
                    //foreach(var business in busiArr)
                    //{
                    //    //string first = Convert.ToString(business);
                    //    //Console.WriteLine(first);
                    //    string letThereBeJson = "{"+$"{business}";
                    //    Console.WriteLine(letThereBeJson);
                    //    businesses.Add(JsonConvert.DeserializeObject<BusinessDto>(letThereBeJson));
                    //}
                    //Console.WriteLine(businesses);
                    break;
                case "3":
                    // This was working the day before the presentation, and then we did a database migration and couldn't get this method to properly post again.

                    HttpResponseMessage businessReviewsResponse = await Client.PostReview();
                    Task<string> reviewPost = businessReviewsResponse.Content.ReadAsStringAsync();
                    ReviewDto review = JsonConvert.DeserializeObject<ReviewDto>(reviewPost.Result);
                    Console.WriteLine(reviewPost.Result);
                    break;
                case "5":
                    HttpResponseMessage businessPostResponse = await Client.PostBusiness();
                    Task<string> postIt = businessPostResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(postIt.Result);
                    break;
                case "0":
                    Client.LogOut();
                    break;
                case "+":
                    HttpResponseMessage data = await Client.GetData("businesses");
                    Task<string> stuff = data.Content.ReadAsStringAsync();
                    Console.WriteLine(stuff.Result);
                    break;
                default:
                    Console.WriteLine("Please select a valid input.");
                    await Menu();
                    break;
            }

            Console.WriteLine("Would you like to do something else?");
            userInput = Console.ReadLine();

            if (userInput.Contains("y".ToLower()))
            {
                await Menu();
            }
        }

        //public async Task ViewReviews()
        //{
        //    Console.WriteLine("What's the name of the business you would like to view your review of?");
        //}
    }
}
