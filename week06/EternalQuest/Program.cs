using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.Write($"\nYou have {goalManager.Score} points (Level {goalManager.Level}).\n\nMenu options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    goalManager.CreateNewGoal();
                    WaitForUser();
                break;
                case "2":
                    goalManager.ListGoals();
                    WaitForUser();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFilename = Console.ReadLine();
                    goalManager.SaveGoals(saveFilename);
                    Thread.Sleep(500);
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? (don't include txt) ");
                    string loadFilename = Console.ReadLine();
                    goalManager.LoadGoals(loadFilename);
                    Thread.Sleep(500);
                    break;
                case "5":
                    goalManager.RecordEvent();
                    WaitForUser();
                    break;
                case "6":
                    Console.Write("Are you sure? Have you saved after recording all your goals? Y/N ");
                    string doQuit = Console.ReadLine();
                    if (doQuit.ToLower() == "y")
                    {
                        quit = true;
                    }
                        break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(500);
                break;
            }
        }

        static void WaitForUser()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}