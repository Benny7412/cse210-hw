using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNum = PromptUserNumber();
        int square = SquareNumber(favNum);
        DisplayResult(name, square);
    }
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName(){
        
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber(){
        Console.WriteLine("Please enter your favorite number");
        int favNum = int.Parse(Console.ReadLine());

        return favNum;
    }

    static int SquareNumber(int num) {
       int square = num * num;
       return square;
    }

    static void DisplayResult(string name, int square){
        Console.WriteLine($"Hello, {name}. Your favorite number squared is: {square}");
    }

}