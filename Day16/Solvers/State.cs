namespace Day16.Solvers;

public class State
{
    public readonly int X;
    public readonly int Y;
    public readonly string Direction;
    public readonly HashSet<string> Seen;

    public State(int x, int y, string direction, HashSet<string> seen)
    {
        X = x;
        Y = y;
        Direction = direction;
        Seen = seen;
    }
}