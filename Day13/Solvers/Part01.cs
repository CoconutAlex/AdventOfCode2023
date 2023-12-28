using Common;

namespace Day13.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int notesSum = CalculateNotesSum(lines);

        return notesSum.ToString();
    }

    private static int CalculateNotesSum(IEnumerable<string> input)
    {
        
        List<Pattern> patterns = new List<Pattern>();
        Pattern pattern = new Pattern();
        foreach (string line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                pattern.ComputeColumns();
                patterns.Add(pattern);
                pattern = new Pattern();
            }
            else
            {
                pattern.AppendLine(line);
            }
        }
        pattern.ComputeColumns();
        patterns.Add(pattern);
        
        int totalSum = patterns.Sum(p => p.GetVerticalReflectionCount()) + 100 * patterns.Sum(p => p.GetHorizontalReflectionCount());
        
        return totalSum;
    }
}