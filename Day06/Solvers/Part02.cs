using Common;

namespace Day06.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long waysΜultiplication = CalculateWaysΜultiplication(lines);

        return waysΜultiplication.ToString();
    }

    private static long CalculateWaysΜultiplication(IReadOnlyList<string> input)
    {
        long[] times =
            { long.Parse(string.Join("", input[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1))) };
        long[] distances =
            { long.Parse(string.Join("", input[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1))) };

        long totalWays = Helpers.CalculateValidWaysToBeatRecord(times, distances);

        return totalWays;
    }
}