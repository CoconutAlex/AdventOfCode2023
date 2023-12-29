using Common;

namespace Day21.Solvers;

public sealed class Part01 : Solver
{
    private static IReadOnlyList<string> _input;
    private const int Steps = 64;

    protected override string Resolve(string[] lines)
    {
        _input = lines;
        
        int gardenPlots = CalculateGardenPlots();

        return gardenPlots.ToString();
    }

    private int CalculateGardenPlots()
    {
        List<int> start = new List<int>();

        for (int i = 0; i < _input.Count; i++)
        {
            for (int j = 0; j < _input[i].Length; j++)
            {
                if (_input[i][j] == 'S')
                {
                    start.Add(i);
                    start.Add(j);
                    break;
                }
            }
        }

        var gardenPlots = _fill(start[0], start[1], Steps);

        return gardenPlots;
    }

    private readonly Func<int, int, int, int> _fill = (sy, sx, steps) =>
    {
        int[][] directions = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };
        HashSet<string> visited = new HashSet<string>();
        List<int[]> plots = new List<int[]> { new[] { sy, sx } };

        int counter = 0;
        while (counter < steps)
        {
            List<int[]> toExplore = plots.ToList();
            plots.Clear();
            visited.Clear();

            foreach (int[] coords in toExplore)
            {
                int x = coords[0];
                int y = coords[1];

                foreach (int[] dir in directions)
                {
                    int newx = x + dir[0];
                    int newy = y + dir[1];

                    if (newy >= 0 && newy < _input.Count && newx >= 0 && newx < _input[newy].Length)
                    {
                        if (_input[newy][newx] != '#' && !visited.Contains($"{newx},{newy}"))
                        {
                            visited.Add($"{newx},{newy}");
                            plots.Add(new[] { newx, newy });
                        }
                    }
                }
            }

            counter++;
        }

        return plots.Count;
    };
}