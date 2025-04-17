using System;
using System.Xml.Linq;

public abstract class Activity
{
    protected DateTime _date;
    protected float _lengthInMinutes;

    //properties
    public DateTime Date { get { return _date; } }
    public float LengthInMinutes { get { return _lengthInMinutes; } }

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary(double weightInKg = 80) // I just put this as the weight of the average adult male for calories burned.
    {
        double calories = CalculateCaloriesBurned(weightInKg);

        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} minutes per mile | Estimated Calories Burned: {calories}";
    }

    public abstract double CalculateCaloriesBurned(double weightInKg);
    protected double CalculateCaloriesFormula(double metValue, double weightInKg)
    {
        return (_lengthInMinutes * metValue * weightInKg) / 200;
    }
}
