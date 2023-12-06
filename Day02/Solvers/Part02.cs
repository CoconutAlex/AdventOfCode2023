using Common;

namespace Day02.Solvers;

public sealed class Part02 : Solver
{
    private static readonly Dictionary<string, List<int>> GameColors = new();

    protected override string Resolve(string[] lines)
    {
        int powerSum = PowerSum(lines);

        return powerSum.ToString();
    }

    private static int PowerSum(IEnumerable<string> games)
    {
        List<int> listOfPowers = new List<int>();
        foreach (var currentGame in games)
        {
            int gamePower = CalculatePower(currentGame);
            listOfPowers.Add(gamePower);
        }

        return listOfPowers.Sum();
    }

    private static int CalculatePower(string game)
    {
        string[] tokens = game.Split("; ");

        GameColors.Clear();

        foreach (var token in tokens)
        {
            var subEvents = token
                .Replace(": ", ":")
                .Substring(token.IndexOf(':') + 1)
                .Split(", ");

            foreach (var subEvent in subEvents)
            {
                string cubeColor = subEvent.Split(' ')[1];
                int numberOfCubes = int.Parse(subEvent.Split(' ')[0].Trim());

                if (!GameColors.TryGetValue(cubeColor, out List<int>? colorList))
                {
                    colorList = new List<int>();
                    GameColors[cubeColor] = colorList;
                }

                colorList.Add(numberOfCubes);
            }
        }

        var power = 1;
        foreach (var gameColors in GameColors)
        {
            if (gameColors.Value.Count > 0) power *= gameColors.Value.Max();
        }

        return power;
    }
}