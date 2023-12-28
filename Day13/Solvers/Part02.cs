using Common;

namespace Day13.Solvers
{
    public sealed class Part02 : Solver
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

            int verticalReflectionCount = 0;
            int horizontalReflectionCount = 0;
            bool found;
            foreach (Pattern p in patterns)
            {
                List<int> originalVerticalReflectionCount = p.GetVerticalReflectionCollection();
                List<int> originalHorizontalReflectionCount = p.GetHorizontalReflectionCollection();
                found = false;
                for (int x = 0; x < p.columns.Count && !found; x++)
                {
                    for (int y = 0; y < p.lines.Count && !found; y++)
                    {
                        p.Swap(x, y);
                        List<int> newVerticalReflectionCount = p.GetVerticalReflectionCollection();
                        List<int> newHorizontalReflectionCount = p.GetHorizontalReflectionCollection();

                        var toRemoveVertical =
                            newVerticalReflectionCount.Except(originalVerticalReflectionCount).ToList();
                        var toRemoveHorizontal = newHorizontalReflectionCount.Except(originalHorizontalReflectionCount)
                            .ToList();

                        if (toRemoveVertical.Count > 0)
                        {
                            if (toRemoveVertical.Count > 1) throw new InvalidOperationException();
                            verticalReflectionCount += toRemoveVertical[0];
                        }

                        if (toRemoveHorizontal.Count > 0)
                        {
                            if (toRemoveHorizontal.Count > 1) throw new InvalidOperationException();
                            horizontalReflectionCount += toRemoveHorizontal[0];
                        }

                        found |= !(toRemoveVertical.Count == 0 && toRemoveHorizontal.Count == 0);
                        p.Swap(x, y);
                    }
                }
            }

            int totalSum = verticalReflectionCount + 100 * horizontalReflectionCount;

            return totalSum;
        }
    }
}