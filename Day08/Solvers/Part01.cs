using Common;

namespace Day08.Solvers;

public sealed class Part01 : Solver
{
    private const string StartNode = "AAA";
    protected override string Resolve(string[] lines)
    {
        int totalSteps = CalculateTotalSteps(lines);

        return totalSteps.ToString();
    }

    private static int CalculateTotalSteps(IEnumerable<string> input)
    {
        IReadOnlyList<string> nonEmptyLines = Utils.RemoveEmptyLines(input);
        
        string instructions = nonEmptyLines[0];
        
        Dictionary<string, (string left, string right)> nodes = new();
        foreach (var line in nonEmptyLines.Skip(1))
        {
            string[] parts = line.Split(" ");
            string node = parts[0].Trim();
            string leftPath = parts[2].TrimStart('(').TrimEnd(',');
            string rightPath = parts[3].TrimEnd(')');
            nodes.Add(node,(leftPath,rightPath));
        }
        
        string currentNode = StartNode;
        
        int steps = 0;
        int i = 0;
        while (currentNode != "ZZZ")
        {
            char instruction = instructions[i];

            var currentNodeValues = nodes[currentNode];
            
            currentNode = instruction == 'L' ? currentNodeValues.left : currentNodeValues.right;
            
            steps++;

            i = (i + 1) % instructions.Length;
        }
        
        return steps;
    }
}