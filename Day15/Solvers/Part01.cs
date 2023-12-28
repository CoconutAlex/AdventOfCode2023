using Common;

namespace Day15.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int sumOfResults = CalculateSumOfResults(lines[0].Split(','));

        return sumOfResults.ToString();
    }

    private static int CalculateSumOfResults(IEnumerable<string> input)
    {
        int result = 0;
        foreach (string str in input)
        {
            result += Helpers.GetHash(str);
        }

        return result;
    }
}