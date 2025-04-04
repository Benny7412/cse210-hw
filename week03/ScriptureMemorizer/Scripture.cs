using System;



class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] wordList = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordList)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));

        return $"{reference} {scriptureText}";

    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleWords = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleWords.Add(i);
            }
        }


        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count == 0)
                break;


            int randomIndex = _random.Next(0, visibleWords.Count);
            int wordIndex = visibleWords[randomIndex];

            _words[wordIndex].Hide();

            visibleWords.RemoveAt(randomIndex);
        }


    }
    public void ResetWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }


}
