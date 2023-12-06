using Common;

namespace Day04.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalPoints = CalculateTotalPoints(lines);

        return totalPoints.ToString();
    }

    private static int CalculateTotalPoints(IEnumerable<string> input)
    {
        int totalPoints = 0;

        foreach (string line in input)
        {
            string[] parts = line.Split(':')[1].Trim().Split(('|'));
            string[] winningNumbers = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] yourNumbers = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int points = CalculatePoints(winningNumbers, yourNumbers);
            totalPoints += points;
        }

        return totalPoints;
    }

    private static int CalculatePoints(IEnumerable<string> winningNumbers, IEnumerable<string> yourNumbers)
    {
        int points = 0;

        HashSet<string> winningSet = new HashSet<string>(winningNumbers);
        HashSet<string> uniqueMatches = new HashSet<string>();

        foreach (string num in yourNumbers)
        {
            if (winningSet.Contains(num) && uniqueMatches.Add(num))
            {
                points = points == 0 ? 1 : points * 2;
            }
        }

        return points;
    }
}