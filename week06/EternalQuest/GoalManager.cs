using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        CalculateLevel();
    }

    public int Level { get { return _level; } }

    public int Score { get { return _score; } }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal); 
    }
    private void CalculateLevel()
    {
        _level = (_score / 1000) + 1;
    }
    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }
        Console.WriteLine("Your goals:\n");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("\n Which goal did you accomplish? ");

        //I don't usually comment but since this might be slightly hard to read I thought I'd explain it.
        //It's only creating goalIndex as a integer if it finds that Console.ReadLine() is an integer that can be parsed otherwise it outputs invalid number.
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];

            if (selectedGoal.IsComplete && selectedGoal is SimpleGoal)
            {
                Console.WriteLine("This goal is already complete. No points awarded.");
            }
            else
            {
                int pointsEarned = selectedGoal.RecordEvent();
                _score += pointsEarned;

                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");

                if (selectedGoal is ChecklistGoal && selectedGoal.IsComplete)
                {
                    Console.WriteLine("Bonus awarded! You have completed this goal!");
                }
                int oldLevel = _level;
                CalculateLevel();
                if (_level > oldLevel)
                {
                    Console.WriteLine($"Congratulations! You've leveled up to level {_level}!");
                }
            }
           } 
            else
           {
            Console.WriteLine("Invalid Number.");
           }
    }

    public void SaveGoals(string filename)
    {
        filename = filename + ".txt";

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score},{_level}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals successfully saved to \"{filename}\".");
    }

    public void LoadGoals(string filename)
    {
        filename = filename + ".txt";
        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string scoreLine = reader.ReadLine();
            string[] scoreData = scoreLine.Split(',');
            _score = int.Parse(scoreData[0]);

            if (scoreData.Length > 1)
            {
                _level = int.Parse(scoreData[1]);
            }
            else
            {
                CalculateLevel();
            }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);
                    bool isComplete = bool.Parse(goalData[3]);

                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }

                else if (goalType == "EternalGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);

                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    int points = int.Parse(goalData[2]);
                    int target = int.Parse(goalData[3]);
                    int bonus = int.Parse(goalData[4]);
                    int timesCompleted = int.Parse(goalData[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, timesCompleted));
                }
            }
        }

        Console.WriteLine("Loaded goals!");
    }

    public void CreateNewGoal()
    {
        bool validChoice = false;
        
        string goalType = "";
        while (!validChoice)
        {
                Console.Write("Types of goals:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal\nWhich type of goal would you like to create? ");

                goalType = Console.ReadLine();
                switch (goalType)
                {
                    case "1":
                        validChoice = true;
                        break;
                    case "2":
                        validChoice = true;
                        break;
                    case "3":
                        validChoice = true;
                        break;
                    default:
                        break;
                }
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string desc = Console.ReadLine();
        Console.Write("How many points would you like this goal to be worth? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal;
        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(name, desc, points);
                _goals.Add(newGoal);
                break;
            case "2":
                newGoal = new EternalGoal(name, desc, points);
                _goals.Add(newGoal);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("How many points will the bonus be? ");
                int bonus = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(name, desc, points, target, bonus);
                _goals.Add(newGoal);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
            Console.WriteLine("Goal created successfully!");
        }
    }


