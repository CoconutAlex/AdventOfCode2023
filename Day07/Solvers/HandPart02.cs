namespace Day07.Solvers;

public class HandPart02 : Hand
{
    public HandPart02(string cards, int bid) : base(cards, bid)
    {
    }

    public override int GetHandStrength()
    {
        int jokerCount = Cards.Count(c => c == 'J');

        int handStrength = true switch
        {
            _ when HasFiveOfAKind() => 7,
            _ when HasFourOfAKind() => (jokerCount > 0) ? 7 : 6,
            _ when HasFullHouse() => jokerCount switch
            {
                2 => 7,
                1 => 6,
                _ => 5
            },
            _ when HasThreeOfAKind() => (jokerCount == 2) ? 7 : (jokerCount == 1) ? 6 : 4,
            _ when HasTwoPair() => (jokerCount == 3) ? 7 : (jokerCount == 2) ? 6 : (jokerCount == 1) ? 5 : 3,
            _ when HasOnePair() => (jokerCount == 3) ? 7 : (jokerCount == 2) ? 6 : (jokerCount == 1) ? 4 : 2,
            _ => (jokerCount == 5 || jokerCount == 4) ? 7 :
                (jokerCount == 3) ? 6 :
                (jokerCount == 2) ? 4 :
                (jokerCount == 1) ? 2 : 1
        };

        HandStrength = handStrength;
        return handStrength;
    }

    protected override List<int> GetOrderedCardValues()
    {
        // Assign values to card labels based on their relative strength
        Dictionary<char, int> cardValues = new Dictionary<char, int>
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
            { 'J', 1 },
        };

        // Order card values based on label
        var orderedValues = Cards.Select(card => cardValues[card]).OrderByDescending(value => value).ToList();

        return orderedValues;
    }

    protected virtual bool HasFiveOfAKind() => Cards.Where(c => c != 'J').GroupBy(c => c).Any(g => g.Count() == 5);

    private bool HasFourOfAKind() => Cards.Where(c => c != 'J').GroupBy(c => c).Any(g => g.Count() == 4);

    private bool HasFullHouse() => Cards.Where(c => c != 'J').GroupBy(c => c)
        .OrderByDescending(g => g.Count())
        .Select(g => g.Count())
        .SequenceEqual(new[] { 3, 2 });

    private bool HasThreeOfAKind() => Cards.Where(c => c != 'J').GroupBy(c => c).Any(g => g.Count() == 3);

    private bool HasTwoPair()
    {
        var cardCounts = Cards.Where(c => c != 'J').GroupBy(c => c).Select(g => g.Count()).ToList();
        return cardCounts.Count switch
        {
            2 => cardCounts.All(count => count == 2),
            3 => cardCounts.Count(count => count == 2) >= 2,
            _ => false
        };
    }

    private bool HasOnePair() => Cards.Where(c => c != 'J').GroupBy(c => c).Any(g => g.Count() == 2);
}