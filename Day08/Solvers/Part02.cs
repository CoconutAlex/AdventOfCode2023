using Common;

namespace Day08.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long totalSteps = CalculateTotalSteps(lines);

        return totalSteps.ToString();
    }

    private static long CalculateTotalSteps(IEnumerable<string> input)
    {
        IReadOnlyList<string> nonEmptyLines = Utils.RemoveEmptyLines(input);

        char[] instructions = nonEmptyLines[0].ToCharArray();

        Dictionary<string, string[]> nodes = new();
        foreach (var line in nonEmptyLines.Skip(1))
        {
            string[] parts = line.Split(" ");
            string node = parts[0].Trim();
            string leftPath = parts[2].TrimStart('(').TrimEnd(',');
            string rightPath = parts[3].TrimEnd(')');
            nodes.Add(node, new[] { leftPath, rightPath });
        }

        List<long> stepsList = new List<long>();
        foreach (string start in nodes.Keys)
        {
            if (start.EndsWith('A'))
            {
                stepsList.Add(SolveSteps(start, instructions, nodes));
            }
        }


        return Utils.CalculateLcm(stepsList);
    }

    private static int SolveSteps(string start, IReadOnlyList<char> inst, IReadOnlyDictionary<string, string[]> conn)
    {
        string pos = start;
        int idx = 0;
        while (!pos.EndsWith('Z'))
        {
            char d = inst[idx % inst.Count];
            pos = conn[pos][d == 'L' ? 0 : 1];
            idx++;
        }

        return idx;
    }
}