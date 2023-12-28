using Common;

namespace Day18.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalCubicMeters = CalculateCubicMeters(lines);

        return totalCubicMeters.ToString();
    }

    private static int CalculateCubicMeters(IEnumerable<string> input)
    {
        List<int> xCoordinates = new List<int>();
        List<int> yCoordinates = new List<int>();
        int xItem = 0;
        int yItem = 0;
        int totalLength = 0;

        foreach (string line in input)
        {
            string[] parts = line.Split(' ');
            string dir = parts[0];
            int numSteps = int.Parse(parts[1]);
            totalLength += numSteps;

            switch (dir)
            {
                case "U":
                    yItem -= numSteps;
                    break;
                case "R":
                    xItem += numSteps;
                    break;
                case "D":
                    yItem += numSteps;
                    break;
                case "L":
                    xItem -= numSteps;
                    break;
            }

            xCoordinates.Add(xItem);
            yCoordinates.Add(yItem);
        }

        double area = Helpers.GetArea(xCoordinates, yCoordinates);
        var cubicMeters = totalLength + (area + 1 - totalLength / 2);
        return (int)cubicMeters;
    }
}