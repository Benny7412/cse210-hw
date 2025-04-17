using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes) 
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _lengthInMinutes) / 60; 
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override double CalculateCaloriesBurned(double weightInKg)
    {
        double metValue;
        double speedMph = GetSpeed();

        if (speedMph > 20) 
            metValue = 10.0;
        else if (speedMph > 15)
            metValue = 8.0;
        else if (speedMph > 10)
            metValue = 6.0;
        else
            metValue = 4.0;

        return base.CalculateCaloriesFormula(metValue, weightInKg);
    }

}
