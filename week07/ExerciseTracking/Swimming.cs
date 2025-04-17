using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Swimming : Activity
{
    private int _laps;
    private const double LapDistanceInMeters = 50;
    private const double MetersToMiles = 0.00062;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
    _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapDistanceInMeters * MetersToMiles;
    }
    public override double GetSpeed()
    {
        return (GetDistance() / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / GetDistance();
    }

    public override double CalculateCaloriesBurned(double weightInKg)
    {
        double metValue = 7.5;

        if (_laps / _lengthInMinutes > 0.5) metValue = 10.0;

        return base.CalculateCaloriesFormula(weightInKg, metValue);
    }
}
