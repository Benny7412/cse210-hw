using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLib lib = new ScriptureLib();
        Scripture scripture = lib.GetRandomScripture();


            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine($" \nPress 'enter' to continue, type 'quit' to finish or type 'new' to get a random scripture \nThere are {lib.GetScriptureCount()} scriptures available. ");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
                else if (input == "new")
                {
                scripture = lib.GetRandomScripture();
                scripture.ResetWords();
                continue;
            }
                scripture.HideRandomWords(3);
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\n All words are now hidden.");
        }
    }
}