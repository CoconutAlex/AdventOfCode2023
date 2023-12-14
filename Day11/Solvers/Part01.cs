using Common;

namespace Day11.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long sumOfLengths = Helpers.CalculateSum(lines, 2);

        return sumOfLengths.ToString();
    }
}