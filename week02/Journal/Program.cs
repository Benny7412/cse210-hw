using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput = 0;
        bool doQuit = false;

        do
        {
            Console.WriteLine("""
                
                Welcome to the Journal Program!
                Please select one of the following choices:
                1. Write
                2. Display
                3. Load
                4. Save
                5. Quit
                What would you like to do?
                
                """);
            try
            {
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        string prompt = PromptGen.PromptUser();
                        ChoiceLogic.WriteToFile(prompt);
                        break;
                    case 2:
                        ChoiceLogic.ReadFile();
                        break;
                    case 3:
                        ChoiceLogic.LoadFile();
                        break;
                    case 4:
                        ChoiceLogic.SaveFile();
                        break;
                    case 5:
                        doQuit = ChoiceLogic.Quit();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Choice.");
            }
        } while (doQuit == false);
    }
}