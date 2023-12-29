using Common;

namespace Day21.Solvers;

public sealed class Part02 : Solver
{
    private static IReadOnlyList<string> _input;
    private const int Steps = 26501365;

    protected override string Resolve(string[] lines)
    {
        _input = lines;

        long gardenPlots = CalculateGardenPlots();

        return gardenPlots.ToString();
    }

    private long CalculateGardenPlots()
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

        int size = _input.Count;
        long gridWidth = (long)Math.Floor((double)Steps / size - 1);
        long odd = (long)Math.Pow(Math.Floor((double)gridWidth / 2) * 2 + 1, 2);
        long even = (long)Math.Pow(Math.Floor(((double)gridWidth + 1) / 2) * 2, 2);
        long oddPoints = _fill(start[0], start[1], size * 2 + 1);
        long evenPoints = _fill(start[0], start[1], size * 2);

        long cornerT = _fill(size - 1, start[1], size - 1);
        long cornerR = _fill(start[0], 0, size - 1);
        long cornerB = _fill(0, start[1], size - 1);
        long cornerL = _fill(start[0], size - 1, size - 1);

        long smallTR = _fill(size - 1, 0, (long)Math.Floor((double)size / 2) - 1);
        long smallTL = _fill(size - 1, size - 1, (long)Math.Floor((double)size / 2) - 1);
        long smallBR = _fill(0, 0, (long)Math.Floor((double)size / 2) - 1);
        long smallBL = _fill(0, size - 1, (long)Math.Floor((double)size / 2) - 1);

        long largeTR = _fill(size - 1, 0, (long)Math.Floor((double)size * 3 / 2) - 1);
        long largeTL = _fill(size - 1, size - 1, (long)Math.Floor((double)size * 3 / 2) - 1);
        long largeBR = _fill(0, 0, (long)Math.Floor((double)size * 3 / 2) - 1);
        long largeBL = _fill(0, size - 1, (long)Math.Floor((double)size * 3 / 2) - 1);

        long gardenPlots = odd * oddPoints + even * evenPoints + cornerT + cornerR + cornerB + cornerL +
                          (gridWidth + 1) * (smallTR + smallTL + smallBR + smallBL) +
                          gridWidth * (largeTR + largeTL + largeBR + largeBL);

        return gardenPlots;
    }

    private readonly Func<int, int, long, long> _fill = (sy, sx, steps) =>
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