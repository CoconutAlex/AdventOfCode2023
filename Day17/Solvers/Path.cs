namespace Day17.Solvers;

public class Path(Position position, Direction direction, int distance)
{
    public Position Position { get; set; } = position;
    public Direction Direction { get; set; } = direction;
    public int Distance { get; set; } = distance;
    public int Heat { get; set; }
}