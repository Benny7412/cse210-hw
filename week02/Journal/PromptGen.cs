using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PromptGen
{

    private static List<string> prompts = new List<string>
    {
       "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I did to progress towards my goals?",
        "How did I impact someone's life today?"
    };
    public static string PromptUser()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        Console.WriteLine(prompts[index]);

        return prompts[index];
    }
    
    
}
