using System;

class Comment {
    private string _commentText;
    private string _commentName;

    public Comment(string text, string commenterName)
    {
        _commentName = commenterName;
        _commentText = text;
    }

    public string CommenterName 
    {
        get {return _commentName; }
    }

    public string Text
    {
        get {return _commentText; }
    }
}