using System;
using System.Collections.Generic;
using System.Threading;

class Activity 
{
    private string _name;
    private string _description;
    private int _duration;

    public string Name 
    {
        get { return _name; }
        protected set { _name = value; } 
    }

    public string Description 
    {
        get { return _description; }
        protected set { _description = value; }
    }
    public int Duration 
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public Activity(string name, string desc) 
    {
        _name = name;
        _description = desc;
        Duration = 0;
    }

    public void DisplayStartingMessage() 
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} \n\n{_description}\nHow long, in seconds, would you like for your session?");
        try
        {
            Duration = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Setting duration to 30 seconds.");
            Duration = 30;
            Thread.Sleep(2000);
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }
    
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}\n");
        ShowSpinner(5);

    }
    public void ShowSpinner(int seconds)
    {
        Console.CursorVisible = false;
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i]);
            Thread.Sleep(100);
            Console.Write("\b");
            i++;
            if (i >= frames.Count)
            {
                i = 0;
            }
        }
        Console.CursorVisible = true;
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}