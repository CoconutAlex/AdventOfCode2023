using Common;

namespace Day02.Solvers;

public sealed class Part01 : Solver
{
    private static readonly Dictionary<string, int> CubeCounts = new()
    {
        { "blue", 14 },
        { "green", 13 },
        { "red", 12 }
    };

    private static readonly Dictionary<string, int> Events = new();

    protected override string Resolve(string[] lines)
    {
        int totalScore = CalculateIdsSum(lines);

        return totalScore.ToString();
    }

    private static int CalculateIdsSum(IEnumerable<string> games)
    {
        List<int> possibleGames = new List<int>();

        foreach (var currentGame in games)
        {
            if (IsPossibleGame(currentGame))
            {
                int gameId = ExtractGameId(currentGame);
                possibleGames.Add(gameId);
            }
        }

        return possibleGames.Sum();
    }

    private static bool IsPossibleGame(string game)
    {
        string[] tokens = game.Split("; ");

        foreach (var token in tokens)
        {
            Events.Clear();

            var subEvents = token
                .Replace(": ", ":")
                .Substring(token.IndexOf(':') + 1)
                .Split(", ");

            foreach (var subEvent in subEvents)
            {
                string cubeColor = subEvent.Split(' ')[1];
                int numberOfCubes = int.Parse(subEvent.Split(' ')[0].Trim());
                Events[cubeColor] = numberOfCubes;
            }

            foreach (var key in Events.Keys)
            {
                if (CubeCounts.TryGetValue(key, out int cubeCountsValue))
                {
                    int subEventValue = Events[key];

                    if (subEventValue > cubeCountsValue)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static int ExtractGameId(string game)
    {
        var id = game.Split(':')[0].Replace("Game", "").Trim();
        return int.Parse(id);
    }
}