using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProblematicProblem
{
    public class Activity
    {
        public List<string> Activities = new List<string>() { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };


        public bool WelcomeAndStart()
        {
            while (true)
            {

                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? Yes or No?: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower().Trim() == "yes")
                {
                    Console.WriteLine("Perfect!");
                    return true;
                }
                else if (userInput.ToLower().Trim() == "no")
                {
                    Console.WriteLine("Thanks, have a great day!");
                    return false;
                }
                else
                {
                    Console.WriteLine("Sorry, invalid input. Try again. \n");
                }
            }
        }

        public static string GetName()
        {
            while (true)
            {
                Console.Write("We are going to need your information first! What is your name?: ");
                string userName = Console.ReadLine();
                return userName;
            }
        }

        public static int GetAge()
        {
            while (true)
            {
                Console.Write("What is your age?: ");
                if (!int.TryParse(Console.ReadLine(), out int userAge))
                {
                    Console.WriteLine("Sorry, invalid input. Try again. \n");
                }
                else
                {
                    return userAge;
                }
            }
        }

        public void ViewList()
        {
            while (true)
            {

                Console.Write("Would you like to see the current list of activities? Yes or No?: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower().Trim() == "yes")
                {
                    foreach (string activity in Activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    AddingInquiry();

                    break;
                }
                else if (userInput.ToLower().Trim() == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, invalid input. Try again. \n");
                }
            }
        }

        public void AddingInquiry()
        {
            while (true)
            {
                Console.Write("Would you like to add any activities before we generate one? Yes or No?: ");
                string addToList = Console.ReadLine();
                Console.WriteLine();

                if (addToList.ToLower().Trim() == "no")
                {
                    break;
                }
                else if (addToList.ToLower().Trim() == "yes")
                {
                    AddingToList();
                    return;
                }
                else
                {
                    Console.WriteLine("Sorry, invalid input. Try again. \n");
                }
            }
        }
        public void AddingToList()
        {
            while (true)
            {
                Console.Write("What would you like to add?: ");
                string userAddition = Console.ReadLine();
                Activities.Add(userAddition);
                foreach (string activity in Activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine();
                while (true)
                {
                    Console.Write("Would you like to add more? Yes or No?: ");
                    string addMore = Console.ReadLine();
                    if (addMore.ToLower().Trim() == "yes")
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (addMore.ToLower().Trim() == "no")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, invalid input. Try again. \n");
                    }
                }
            }
        }
        public void ChoosingAndTryAgain(string userName, int userAge)
        {
            Random rng = new Random();
            bool cont = true;
            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine();
                int randomNumber = rng.Next(Activities.Count);
                string randomActivity = Activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    Activities.Remove(randomActivity);
                    randomNumber = rng.Next(Activities.Count);
                    randomActivity = Activities[randomNumber];
                }
                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}!");
                Console.Write("Is this ok or do you want to grab another activity? Keep or Redo?: ");
                string keepOrRedo = Console.ReadLine();
                Console.WriteLine();
                while (true)
                {
                    if (keepOrRedo.ToLower().Trim() == "keep")
                    {
                        cont = false;
                        return;
                    }
                    else if (keepOrRedo.ToLower().Trim() == "redo")
                    {
                        cont = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, invlaid input. Try again.");
                    }
                }
            }
        }
    }
}
