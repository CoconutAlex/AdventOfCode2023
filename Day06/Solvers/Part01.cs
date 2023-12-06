using Common;

namespace Day06.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long waysΜultiplication = CalculateWaysΜultiplication(lines);

        return waysΜultiplication.ToString();
    }

    private static long CalculateWaysΜultiplication(IReadOnlyList<string> input)
    {
        long[] times = input[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse)
            .ToArray();
        long[] distances = input[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse)
            .ToArray();
        
        long totalWays = Helpers.CalculateValidWaysToBeatRecord(times,distances);

        return totalWays;
    }
}