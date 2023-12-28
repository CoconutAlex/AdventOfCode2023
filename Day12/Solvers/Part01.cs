using System.Text.RegularExpressions;
using Common;

namespace Day12.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalSum = CalculateTotalSum(lines);

        return totalSum.ToString();
    }

    private static int CalculateTotalSum(IEnumerable<string> input)
    {
        var damageList = ParseInput(input);

        foreach (var record in damageList)
        {
            var damagedIndices = Regex.Matches(record.Conditions, @"\?").Select(m => m.Index).ToList();
            record.PossibleArrangements = new List<string>();

            for (int bits = 0; bits < (1 << damagedIndices.Count); bits++)
            {
                int i = 0;
                var arrangement = Regex.Replace(record.Conditions, @"\?", m => ".#"[bits >> i++ & 1].ToString());
                var runs = DamageRuns(arrangement);

                if (ArrayEqual(runs, record.RunLengths))
                {
                    record.PossibleArrangements.Add(arrangement);
                }

                record.PossibleCount = record.PossibleArrangements.Count;
            }
        }

        int totalArrangements = damageList.Sum(r => r.PossibleCount);

        return totalArrangements;
    }

    private static List<int> DamageRuns(string arrangement)
    {
        return Regex.Matches(arrangement, @"#+").Select(m => m.Length).ToList();
    }

    private static bool ArrayEqual(IReadOnlyCollection<int> a, IReadOnlyCollection<int> b)
    {
        return a.Count == b.Count && a.Zip(b, (x, y) => x == y).All(equal => equal);
    }

    private static Damage ParseRecord(string line)
    {
        var parts = line.Split(' ');
        var conditions = parts[0];
        var runString = parts[1];
        var runLengths = runString.Split(',').Select(int.Parse).ToList();
        return new Damage { Conditions = conditions, RunLengths = runLengths };
    }

    private static List<Damage> ParseInput(IEnumerable<string> input)
    {
        return input.Select(ParseRecord).ToList();
    }
}