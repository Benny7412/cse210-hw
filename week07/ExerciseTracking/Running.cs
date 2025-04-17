using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _lengthInMinutes) * 60;
    }
    public override double GetPace()
    {
        return _lengthInMinutes / _distance;
    }

    public override double CalculateCaloriesBurned(double weightInKg)
    {
        double metValue;
        double paceMinPerMile = GetPace();

        if (paceMinPerMile < 6)
            metValue = 12.0;
        else if (paceMinPerMile < 8)
            metValue = 10.0;
        else if (paceMinPerMile < 10)
            metValue = 8.5;
        else
            metValue = 7.0;

        return base.CalculateCaloriesFormula(weightInKg, metValue);
    }
}
