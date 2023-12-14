using Common;

namespace Day11.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long sumOfLengths = Helpers.CalculateSum(lines, 1000000);

        return sumOfLengths.ToString();
    }
}