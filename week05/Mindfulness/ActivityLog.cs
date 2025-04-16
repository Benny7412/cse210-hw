using System;

class ActivityLog
{
    public string ActivityName { get; set; }
    public DateTime Timestamp { get; set; }
    public int Duration { get; set; }

    public ActivityLog(string name, int duration)
    {
        ActivityName = name;
        Duration = duration;
        Timestamp = DateTime.Now;
    }
}