using System;
using System.Collections.Generic;

class Program
{

    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        List<string> words = new List<string>();

        int num;
        int count = 0;
        int lowest = 0;
        int highest = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do 
        {
            Console.WriteLine("Enter number: ");
            num = int.Parse(Console.ReadLine());
            
            if (num != 0){
                if (num > 0 && lowest == 0){
                    lowest = num;
                    highest = num;
                }else if(num > highest){
                    highest = num;
                }else if(num < lowest && num > 0){
                    lowest = num;
                }
                numbers.Add(num);
                count++;
            }
        }while (num != 0);

        Console.WriteLine($"Sum: {numbers.Sum()}\nThe Average is: {numbers.Average()} \nLowest Positive Number: {lowest}\nHighest number: {highest}");
    }


}