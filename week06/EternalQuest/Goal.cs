using System;

public abstract class Goal 
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    //properties
    public string Name { get { return _name; } }
    public int Points { get { return _points; } }
    public bool IsComplete { get { return _isComplete; } }

    public Goal(string name, string description, int points) 
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;    
    }

    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();
    public abstract string GetDetailsString();

}