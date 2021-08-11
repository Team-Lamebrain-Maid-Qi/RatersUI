using System;

namespace RatersUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.GetDataWithAuthentication();
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

        // methods for each api call here
    }
}
