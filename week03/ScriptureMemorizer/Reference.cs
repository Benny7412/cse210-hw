using System;


class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _singleVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _singleVerse = true;
    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
        _singleVerse = false;
    }
    public string GetDisplayText() 
    {
        if (_singleVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

