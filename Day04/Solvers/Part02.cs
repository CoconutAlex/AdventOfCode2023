using Common;

namespace Day04.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalScratchcards = CalculateTotalScratchcards(lines);
        return totalScratchcards.ToString();
    }

    private static int CalculateTotalScratchcards(IEnumerable<string> input)
    {
        int[] totalCopies = Enumerable.Repeat(1, input.Count()).ToArray();

        var index = 0;
        foreach (string line in input)
        {
            string[] parts = line.Split(':')[1].Trim().Split(('|'));
            string[] winningNumbers = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] yourNumbers = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int matches = CalculateMatches(winningNumbers, yourNumbers);

            for (int i = index + 1; i <= index + matches; i++)
            {
                for (int j = 0; j < totalCopies[index]; j++)
                {
                    totalCopies[i] += 1;
                }
            }

            index++;
        }

        return totalCopies.Sum();
    }

    private static int CalculateMatches(IEnumerable<string> winningNumbers, IEnumerable<string> yourNumbers)
    {
        int matches = 0;

        HashSet<string> winningSet = new HashSet<string>(winningNumbers);
        HashSet<string> uniqueMatches = new HashSet<string>();

        foreach (string num in yourNumbers)
        {
            if (winningSet.Contains(num) && uniqueMatches.Add(num))
            {
                matches++;
            }
        }

        return matches;
    }
}