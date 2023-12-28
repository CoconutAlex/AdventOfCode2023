using Common;

namespace Day16.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalSomething = CalculateSomething(lines);

        return totalSomething.ToString();
    }

    private static int CalculateSomething(IEnumerable<string> input)
    {
        return 0;
    }
}