using System;

public abstract class Activity
{
    protected DateTime _date;
    protected float _lengthInMinutes;

    //properties
    public string Name { get { return _name; } }
    public DateTime Date { get { return _date; } }
    public float LengthInMinutes { get { return _lengthInMinutes; } }


    public Activity(string name, DateTime date, float lengthInMinutes)
    {
        _name = name;
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }
}
