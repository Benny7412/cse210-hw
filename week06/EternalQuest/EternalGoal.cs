using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points},false";
    }

    public override string GetDetailsString()
    {
        return $"{_name} ({_description}) - Eternal";
    }
}
