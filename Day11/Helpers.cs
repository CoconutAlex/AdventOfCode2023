namespace Day11;

public class Helpers
{
    private static readonly List<List<string>> Map = new();
    private static readonly List<List<int>> Galaxies = new();

    public static long CalculateSum(IEnumerable<string> lines, int expansion)
    {
        Map.Clear();
        Galaxies.Clear();

        foreach (var line in lines)
        {
            List<string> symbols = new List<string>();
            foreach (var symbol in line)
            {
                symbols.Add(symbol.ToString());
            }

            Map.Add(symbols);
        }

        for (int i = 0; i < Map.Count; i++)
        {
            for (int j = 0; j < Map[i].Count; j++)
            {
                if (Map[i][j] != "#") continue;
                Map[i][j] = (Galaxies.Count + 1).ToString();
                Galaxies.Add(new List<int> { int.Parse(Map[i][j]), i, j });
            }
        }

        long totalSteps = 0;

        for (int i = 0; i < Galaxies.Count; i++)
        {
            for (int j = i + 1; j < Galaxies.Count; j++)
            {
                int yGalaxy = Galaxies[i][1];
                int xGalaxy = Galaxies[i][2];

                int steps = 0;
                int yFinal = Galaxies[j][1];
                int xFinal = Galaxies[j][2];
                string start = Map[yGalaxy][xGalaxy];
                bool flag = xFinal - xGalaxy < 0;

                while (start != Map[yFinal][xFinal])
                {
                    int current = 1;
                    if (yFinal != yGalaxy)
                    {
                        yGalaxy++;
                        start = Map[yGalaxy][xGalaxy];
                        if (EmptyRow(yGalaxy)) current = expansion;
                    }
                    else if (xFinal != xGalaxy)
                    {
                        xGalaxy += flag ? -1 : 1;
                        start = Map[yGalaxy][xGalaxy];
                        if (EmptyColumn(xGalaxy)) current = expansion;
                    }

                    steps += 1 * current;
                }

                totalSteps += steps;
            }
        }

        return totalSteps;
    }

    private static bool EmptyColumn(int y)
    {
        return Map.All(line => line[y] == ".");
    }

    private static bool EmptyRow(int x)
    {
        return Map[x].All(ch => ch == ".");
    }
}