namespace Day07.Solvers;

internal class HandComparerPart02 : IComparer<HandPart02>
{
    private readonly Dictionary<char, int> _cardValues = new Dictionary<char, int>
    {
        { 'A', 13 },
        { 'K', 12 },
        { 'Q', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
        { 'J', 1 }
    };

    public int Compare(HandPart02 x, HandPart02 y)
    {
        int result = CompareChars(x.Cards, y.Cards);

        if (result == 0)
        {
            result = CompareChars(x.Cards.Substring(1), y.Cards.Substring(1));
        }

        return result;
    }

    private int CompareChars(string x, string y)
    {
        for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
        {
            int xCardValue = _cardValues[x[i]];
            int yCardValue = _cardValues[y[i]];

            int charComparison = xCardValue.CompareTo(yCardValue);
            if (charComparison != 0)
            {
                return charComparison;
            }
        }

        return 0;
    }
}