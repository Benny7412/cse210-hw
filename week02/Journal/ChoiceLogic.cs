using System;
using System.IO;

class ChoiceLogic
{
    private static readonly string _cdir = Directory.GetCurrentDirectory();
    private static string _fileName = Path.Combine(_cdir, "tempJournal.txt");
    private static int _unsavedEntries = 0;
    public static void WriteToFile(string prompt) 
    {
        string userInput = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(_fileName, append: true))
        {
            outputFile.WriteLine($"Date: {DateTime.Now} Prompt - {prompt}\n{userInput}\n\n");
            Console.WriteLine($"\nFile saved at: {Path.GetFullPath(_fileName)}");
        }
        _unsavedEntries += 1;
    }

    public static void ReadFile()
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    public static void LoadFile()
    {
        Console.WriteLine($"What file would you like to load? (do not include .txt) \nMust be in {_cdir}");
        string filePath = $"{Console.ReadLine()}.txt";
        _fileName = filePath;
        Console.WriteLine($"Now reading/writing {filePath}");
    }

    public static void SaveFile()
    {
        Console.WriteLine("What would you like to name the file? (do not include .txt)");
        string newFileName = $"{Console.ReadLine()}.txt" ;
        File.Move(_fileName, newFileName);
        _unsavedEntries = 0;
    }

    public static bool Quit()
    {
        bool doQuit = false;
        if (_unsavedEntries > 0)
        {
            Console.WriteLine($"Are you sure you want to quit without saving?\nAmount of unsaved entries {_unsavedEntries}\n\n1: Yes\n2: No");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 2)
            {
                doQuit = false;
            }
            else {
                Console.WriteLine($"{_cdir}\n {_fileName}");
                if (File.Exists(_fileName))
                {
                    File.Delete(_fileName);
                }
                doQuit = true;
            }
        }else
        {
            doQuit = true;
        }

            return doQuit;
    }

}

