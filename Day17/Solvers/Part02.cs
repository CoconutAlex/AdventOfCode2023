using Common;

namespace Day17.Solvers;

public sealed class Part02 : Solver
{
    private static int[][] _map;

    private static readonly PriorityQueue<Path, int> Queue = new();
    private static readonly HashSet<string> Visited = new();
    protected override string Resolve(string[] lines)
    {
        int leastHeatLoss = CalculateLeastHeatLoss(lines);

        return leastHeatLoss.ToString();
    }

    private static int CalculateLeastHeatLoss(IEnumerable<string> input)
    {
        _map = input.Select(s => s.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        Queue.Enqueue(new Path(new(0, 0), Direction.Right, 0), 0);

        var totalHeat = 0;

        Queue.Enqueue(new Path(new(0, 0), Direction.Right, 0), 0);
        Queue.Enqueue(new Path(new(0, 0), Direction.Down, 0), 0);
        totalHeat = 0;
        Visited.Clear();
        
        while (Queue.Count > 0)
        {
            var path = Queue.Dequeue();
            if (path.Position.Row == _map.Length - 1 && path.Position.Col == _map[0].Length - 1)
            {
                totalHeat = path.Heat;
                break;
            }
        
            if (path.Distance < 10)
            {
                TryMove(path, path.Direction);
            }
        
            if (path.Distance >= 4)
            {
                TryMove(path, path.Direction.TurnLeft());
                TryMove(path, path.Direction.TurnRight());
            }
        }
        
        return totalHeat;
    }
    
    private static void TryMove(Path path, Direction direction)
    {
        var candidate = new Path(path.Position.Move(direction), direction,
            direction == path.Direction ? path.Distance + 1 : 1);

        if (candidate.Position.Row < 0 || candidate.Position.Row >= _map.Length ||
            candidate.Position.Col < 0 || candidate.Position.Col >= _map[0].Length)
        {
            return;
        }

        var key =
            $"{candidate.Position.Row},{candidate.Position.Col},{candidate.Direction.Row},{candidate.Direction.Col},{candidate.Distance}";
        if (Visited.Contains(key))
        {
            return;
        }

        Visited.Add(key);

        candidate.Heat = path.Heat + _map[candidate.Position.Row][candidate.Position.Col];
        Queue.Enqueue(candidate, candidate.Heat);
    }
}