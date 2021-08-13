using Newtonsoft.Json;
using RatersUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RatersUI
{
    public class Client
    {
        public static readonly HttpClient client = new();
        private static readonly string APIUrl = "https://ratersofthelostbusiness20210813083125.azurewebsites.net/api/";
        private static string Token { get; set; }
        private static ReviewerDto Reviewer { get; set; }
        private static string Id { get; set; }
        private static int ReviewerId { get; set; }

        public static async Task<HttpResponseMessage> GetData(string path)
        {
            return await client.GetAsync(APIUrl + path);
        }

        public static async Task<HttpResponseMessage> Login()
        {
            Console.WriteLine("Please enter your username");
            Login user = new();
            user.username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            user.password = Console.ReadLine();

            HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "users/login", user);

            return response;
        }

        public static void LogOut()
        {
            Token = null;
            Reviewer = null;
            ReviewerId = 0;
        }

        public static void SetToken(UserDto user)
        {
            Token = user.Token;
        }

        public static void SetId(UserDto user)
        {
            Id = user.Id;
        }

        //public static void SetReviewer(UserDto user)
        //{
          //  Reviewer = user.Reviewer;
        //}

        public static void SetReviewerId(UserDto user)
        {
            ReviewerId = user.ReviewerId;
        }

        public static async Task<HttpResponseMessage> PostBusiness()
        {
            BusinessDto business = new();
            Console.WriteLine("Please enter the business name");
            business.Name = Console.ReadLine();

            Console.WriteLine($"What city is {business.Name} located in?");
            business.City = Console.ReadLine();

            Console.WriteLine($"Which state is {business.Name} located in?");
            business.State = Console.ReadLine();

            Console.WriteLine($"What is the street address of {business.Name}");
            business.Address = Console.ReadLine();

            Console.WriteLine($"What is {business.Name}'s phone number?");
            business.PhoneNumber = Console.ReadLine();

            Console.WriteLine($"What services does {business.Name} provide?");
            business.Type = Console.ReadLine();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "businesses", business);

            return response;
        }

        public static async Task<HttpResponseMessage> PostUser()
        {
            newUserDto newUser = new();

            Console.WriteLine("What would you like your username to be?");
            newUser.UserName = Console.ReadLine();

            Console.WriteLine("Please choose a password.");
            newUser.Password = Console.ReadLine();

            Console.WriteLine("What's your email?");
            newUser.Email = Console.ReadLine();

            Console.WriteLine("Lastly, please enter your phone number.");
            newUser.PhoneNumber = Console.ReadLine();

            HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "users/register", newUser);

            return response;
        }

        public static async Task<HttpResponseMessage> PostReview()
        {
            ReviewDto review = new();
            Console.WriteLine("What is the name of the business you would like to review?");
            string busiName = Console.ReadLine();
            
            HttpResponseMessage busiTask = await GetData($"businesses/businesses/{busiName}");
            Task<string> busiResult = busiTask.Content.ReadAsStringAsync();
            BusinessDto business = JsonConvert.DeserializeObject<BusinessDto>(busiResult.Result);
            review.BusinessId = 2;

            Console.WriteLine("What score out of 5 would you like to give this business?");
            string rating = Console.ReadLine();
            review.Rating = Convert.ToDecimal(rating);

            Console.WriteLine("What would you like to say about this business?");
            review.Review = Console.ReadLine();

            review.ReviewerId = ReviewerId;

            HttpResponseMessage author = await GetData(APIUrl + $"reviewers/{ReviewerId}");
            Task<string> authorObj = author.Content.ReadAsStringAsync();
            ReviewerDto reviewer = JsonConvert.DeserializeObject<ReviewerDto>(authorObj.Result);
            review.Reviewer = reviewer;

            HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "businessreviews", review);

            return response;
        }

        public static async Task<HttpResponseMessage> BusinessByName()
        {
            ReviewDto review = new();
            Console.WriteLine("What is the name of the business you would like to review?");
            //string busiName = Console.ReadLine();

            HttpResponseMessage response = await GetData($"businesses");

            return response;
        }


        public static async Task<HttpResponseMessage> RegisterUser()
        {
            newUserDto user = new();
            Console.WriteLine("What username would you like?");
            user.UserName = Console.ReadLine();

            Console.WriteLine("Please choose a password, this must contain one capital letter, and one special character.");
            user.Password = Console.ReadLine();

            Console.WriteLine("What is your email?");
            user.Email = Console.ReadLine();

            Console.WriteLine("What is your phone number?");
            user.PhoneNumber = Console.ReadLine();

            HttpResponseMessage response = await client.PostAsJsonAsync(APIUrl + "users/register", user);

            return response;
        }

       //public static async Task GetReviews()
        //{
        //    GetData("");
        //}
    }
}