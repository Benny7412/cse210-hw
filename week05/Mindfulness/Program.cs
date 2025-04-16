using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    //added activityLog.cs as well as the DisplayStats() method.
    static List<ActivityLog> activityHistory = new List<ActivityLog>();

    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Menu options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. View stats\n  5. Quit\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityHistory.Add(new ActivityLog(breathing.Name, breathing.Duration));
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    activityHistory.Add(new ActivityLog(reflecting.Name, reflecting.Duration));
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityHistory.Add(new ActivityLog(listing.Name, listing.Duration));
                    break;
                case "4":
                    DisplayStats();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    static void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine("===== Your Mindfulness Journey =====");

        if (activityHistory.Count == 0)
        {
            Console.WriteLine("No activities completed yet. Start your mindfulness journey today!");
        }
        else
        {
            int totalTime = 0;
            foreach (var activity in activityHistory)
            {
                totalTime += activity.Duration;
            }

            Console.WriteLine($"Total activities completed: {activityHistory.Count}");
            Console.WriteLine($"Total time spent on mindfulness: {totalTime} seconds");

            Console.WriteLine("\nActivities by type:");
            Dictionary<string, int> activityCounts = new Dictionary<string, int>();
            Dictionary<string, int> activityTimes = new Dictionary<string, int>();

            foreach (var activity in activityHistory)
            {
                if (!activityCounts.ContainsKey(activity.ActivityName))
                {
                    activityCounts[activity.ActivityName] = 0;
                    activityTimes[activity.ActivityName] = 0;
                }

                activityCounts[activity.ActivityName]++;
                activityTimes[activity.ActivityName] += activity.Duration;
            }

            foreach (var pair in activityCounts)
            {
                string name = pair.Key;
                int count = pair.Value;
                int time = activityTimes[name];
                Console.WriteLine($"- {name}: {count} sessions ({time} seconds)");
            }

            Console.WriteLine("\nYour recent mindfulness sessions:");
            List<ActivityLog> sortedActivities = new List<ActivityLog>(activityHistory);
            sortedActivities.Sort((a, b) => b.Timestamp.CompareTo(a.Timestamp));

            int showCount = Math.Min(5, sortedActivities.Count);
            for (int i = 0; i < showCount; i++)
            {
                ActivityLog log = sortedActivities[i];
                Console.WriteLine($"- {log.ActivityName} for {log.Duration} seconds on {log.Timestamp.ToString("g")}");
            }
        }

        Console.WriteLine("\nPress enter to return to the menu.");
        Console.ReadLine();
    }
}