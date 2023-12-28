namespace Day15;

public class Helpers
{
    public static int GetHash(string input)
    {
        int hash = 0;

        foreach (char c in input)
        {
            hash += c;
            hash *= 17;
            hash %= 256;
        }

        return hash;
    }
}