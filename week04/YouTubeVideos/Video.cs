using System;

class Video
{
    private string _title;
    private string _author;
    private int _seconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _seconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

public string GetFormattedTime()
{
    int hours = _seconds / 3600;
    if (hours != 0) {
        int minutes = (_seconds % 3600) / 60;
        int seconds = (_seconds % 3600) % 60;
        return $"{hours}:{minutes:D2}:{seconds:D2}";
    } else {
        int minutes = _seconds / 60;
        int seconds = _seconds % 60;
        return $"{minutes}:{seconds:D2}";
    }
}
    public string Title 
    {
        get { return _title; }
    }
    public string Author 
    {
        get { return _author; }
    }
    public int LengthInSeconds 
    {
        get { return _seconds; }
    }
    
    public void AddComment(Comment comment) 
    {
        _comments.Add(comment);
    }
    public int GetCommentCount() 
    {
        return _comments.Count;
    }
    public List<Comment> GetComments()
    {
        return _comments;
    }
}