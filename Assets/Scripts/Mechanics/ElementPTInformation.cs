using UnityEngine;

public class ElementPTInformation
{
    public readonly int Number;
    public readonly string Symbol;
    public readonly string Name;
    public readonly string EnglishName;
    public readonly ElementGroup Group;
    public readonly float X;
    public readonly float Y;
    public Color BackColor => Constants.PTColors[Group].backColor;
    public Color TextColor => Constants.PTColors[Group].textColor;

    public ElementPTInformation(int number, string symbol, string name, string englishName, ElementGroup group, float x, float y)
    {
        Number = number;
        EnglishName = englishName;
        Symbol = symbol;
        Name = name;
        Group = group;
        X = x;
        Y = y;
    }
}
