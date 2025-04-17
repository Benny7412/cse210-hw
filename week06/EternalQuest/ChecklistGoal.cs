using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class ChecklistGoal : Goal
{
    private int _target;
    private int _timesCompleted;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
        _isComplete = _timesCompleted >= _target;
    }


    public override int RecordEvent()
    {
        _timesCompleted++;

        if (_timesCompleted == _target)
        {
            _isComplete = true;
            return _points + _bonus;
        }
        else if (_timesCompleted > _target)
        {
            return _points;
        }
        else
        {
            return _points;
        }
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_target},{_bonus},{_timesCompleted}";
    }
    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) - Completed {_timesCompleted}/{_target} times" ;
    }
}

