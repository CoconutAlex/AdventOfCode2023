namespace Day07.Solvers;

public abstract class Hand
{
    public string Cards { get; set; }
    public int Bid { get; set; }
    public int HandStrength { get; set; }

    public abstract int GetHandStrength();

    protected abstract List<int> GetOrderedCardValues();

    public int CompareTo(HandPart01 other)
    {
        //Compare hands of the same type
        if (GetHandStrength() == other.GetHandStrength())
        {
            var thisCards = GetOrderedCardValues();
            var otherCards = other.GetOrderedCardValues();

            for (int i = 0; i < thisCards.Count; i++)
            {
                if (thisCards[i] != otherCards[i])
                {
                    return thisCards[i] - otherCards[i];
                }
            }

            //If all cards are equal, compare the first card
            return thisCards[0] - otherCards[0];
        }

        return 0;
    }
}