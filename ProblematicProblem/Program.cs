using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Activity activities = new Activity();

            if (!activities.WelcomeAndStart())
            {
                return;
            }
            Console.WriteLine();

            string userName = Activity.GetName();
            Console.WriteLine();

            int userAge = Activity.GetAge();
            Console.WriteLine();

            activities.ViewList();
            Console.WriteLine();

            activities.ChoosingAndTryAgain(userName, userAge);
        }
    }
}
