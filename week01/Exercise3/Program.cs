using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your magic number?");
        string userInput = Console.ReadLine();

        int userInputNum = int.Parse(userInput);
        int guessNum = 0;
        int guessCount = 0;

        while(guessNum != userInputNum)
        {
            Console.WriteLine("Guess a number!");
            guessNum = int.Parse(Console.ReadLine());
            guessCount += 1;
            
            if(guessNum > userInputNum)
            {
                Console.WriteLine("Lower");
            }
            else if (guessNum < userInputNum)
            {
                Console.WriteLine("Higher");
            }
            else 
            {
                Console.WriteLine("You guessed correctly!");
                Console.WriteLine($"You guessed in {guessCount} guesses!");
            }

        }

    }
}