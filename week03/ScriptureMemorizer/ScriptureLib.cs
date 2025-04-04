using System;



class ScriptureLib
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLib()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        InitializeLibrary();
    }
    private void InitializeLibrary()
    {
        Scripture scripture1 = new Scripture(new Reference("Luke", 3, 6, 7), "And all flesh shall see the salvation of God. Then said he to the multitude that came forth to be baptized of him, O generation of vipers, who hath warned you to flee from the wrath to come?");
        Scripture scripture2 = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        Scripture scripture3 = new Scripture(new Reference("Alma", 2, 6), "And thus they did assemble themselves together to cast in their voices concerning the matter; and they were laid before the judges.");
        Scripture scripture4 = new Scripture(new Reference("Matthew", 5, 14, 16), "Ye are the light of the world. A city that is set on an hill cannot be hid. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven.");

        _scriptures.Add(scripture1);
        _scriptures.Add(scripture2);
        _scriptures.Add(scripture3);
        _scriptures.Add(scripture4);
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        int randomIndex = _random.Next(0, _scriptures.Count);
        return _scriptures[randomIndex];
    }

    public int GetScriptureCount()
    {
        return _scriptures.Count;
    }
}

