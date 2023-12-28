using Common;

namespace Day15.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int powerOfResultingLens = CalculatePowerOfResultingLens(lines[0].Split(','));

        return powerOfResultingLens.ToString();
    }

    private static int CalculatePowerOfResultingLens(IEnumerable<string> input)
    {
        List<string>[] boxes = new List<string>[256];
        for (int i = 0; i < 256; i++)
        {
            boxes[i] = new List<string>();
        }

        Dictionary<string, int> focalLengths = new Dictionary<string, int>();

        foreach (string step in input)
        {
            if (step.Contains('-'))
            {
                string label = step.Substring(0, step.Length - 1);
                int index = Helpers.GetHash(label);

                boxes[index].RemoveAll(l => l == label);
            }
            else
            {
                string[] parts = step.Split('=');
                string label = parts[0];
                int lengthValue = int.Parse(parts[1]);

                int index = Helpers.GetHash(label);
                if (!boxes[index].Contains(label))
                {
                    boxes[index].Add(label);
                }

                focalLengths[label] = lengthValue;
            }
        }

        int total = 0;

        for (int i = 0; i < boxes.Length; i++)
        {
            for (int j = 0; j < boxes[i].Count; j++)
            {
                string label = boxes[i][j];
                total += (i + 1) * (j + 1) * focalLengths[label];
            }
        }

        return total;
    }
}