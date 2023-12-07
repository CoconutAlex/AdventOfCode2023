using Common;

namespace Day07.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalWinnings = CalculateTotalWinnings(lines);

        return totalWinnings.ToString();
    }

    private static int CalculateTotalWinnings(IEnumerable<string> input)
    {
        int totalWinnings = 0;
        var orderedHands = GetOrderWinningsHands(input);

        for (int i = 0; i < orderedHands.Count; i++)
        {
            totalWinnings += orderedHands[i].Bid * (i + 1);
        }

        return totalWinnings;
    }

    private static List<HandPart02> GetOrderWinningsHands(IEnumerable<string> hands)
    {
        List<HandPart02> handList = hands.Select(hand =>
        {
            var splitHand = hand.Split(' ');
            var cards = splitHand[0];
            var bid = int.Parse(splitHand[1]);

            return new HandPart02(cards, bid);
        }).ToList();

        var customComparer = new HandComparerPart02();

        var orderedHands = handList
            .OrderBy(h => h.GetHandStrength())
            .ThenBy(h => h, customComparer)
            .ToList();

        return orderedHands;
    }
}