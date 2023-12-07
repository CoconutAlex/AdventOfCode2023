namespace Day07.Solvers;

public class HandPart01 : Hand
{
    public HandPart01(string cards, int bid) : base(cards, bid)
    {
    }

    public override int GetHandStrength()
    {
        int handStrength = true switch
        {
            _ when HasFiveOfAKind() => 7,
            _ when HasFourOfAKind() => 6,
            _ when HasFullHouse() => 5,
            _ when HasThreeOfAKind() => 4,
            _ when HasTwoPair() => 3,
            _ when HasOnePair() => 2,
            _ => 1
        };

        HandStrength = handStrength;
        return handStrength;
    }

    protected override List<int> GetOrderedCardValues()
    {
        // Assign values to card labels based on their relative strength
        Dictionary<char, int> cardValues = new Dictionary<char, int>
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            { 'J', 11 },
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 }
        };

        // Order card values based on label
        var orderedValues = Cards.Select(card => cardValues[card]).OrderByDescending(value => value).ToList();

        return orderedValues;
    }

    protected virtual bool HasFiveOfAKind() => Cards.GroupBy(c => c).Any(g => g.Count() == 5);

    private bool HasFourOfAKind() => Cards.GroupBy(c => c).Any(g => g.Count() == 4);

    private bool HasFullHouse() => Cards.GroupBy(c => c).OrderByDescending(g => g.Count())
        .Select(g => g.Count())
        .SequenceEqual(new[] { 3, 2 });

    private bool HasThreeOfAKind() => Cards.GroupBy(c => c).Any(g => g.Count() == 3);

    private bool HasTwoPair() => Cards.GroupBy(c => c).OrderByDescending(g => g.Count())
        .Select(g => g.Count())
        .SequenceEqual(new[] { 2, 2, 1 });

    private bool HasOnePair() => Cards.GroupBy(c => c).Any(g => g.Count() == 2);
}