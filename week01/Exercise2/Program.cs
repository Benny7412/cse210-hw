using System;


class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("What is your grade percentage?");
        string gradePercentage = Console.ReadLine();
        int gradeNumber = int.Parse(gradePercentage);

        string grade = "";

        //added the logic inside so that it will only run the necessary if statements as well as handling A+, F-, and F+ not existing.
        if(gradeNumber >= 90){
            if(gradeNumber >= 93){
                grade = "A";
            }else {
                grade = "A-";
            };
        }else if(gradeNumber >= 80){
            if(gradeNumber >= 87){
                grade = "B+";
            }else if(gradeNumber <= 83) {
                grade = "B-";
            }else{
                grade = "B";
            }
        }else if(gradeNumber >= 70){
            if(gradeNumber >= 77){
                grade = "C+";
            }else if(gradeNumber <= 73) {
                grade = "C-";
            }else{
                grade = "C";
            }
        }else if(gradeNumber >= 60){
            if(gradeNumber >= 67){
                grade = "D+";
            }else if(gradeNumber <= 63) {
                grade = "D-";
            }else{
                grade = "D";
            }
        }else{
            grade = "F";
        }
        
        Console.WriteLine($"Your grade is: {grade}");

        if (gradeNumber >= 70)
        {
            Console.WriteLine("You passed!");
        }else{
            Console.WriteLine("Unfortunately, you will have to retake this class.");
        }

    }
}