namespace Day14.Solvers;

public class Direction
{
    public readonly int Row;
    public readonly int Col;

    public Direction(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public Direction Add(Direction other)
    {
        return new Direction(Row + other.Row, Col + other.Col);
    }

    public Direction Reverse()
    {
        return new Direction(-Row, -Col);
    }

    public Direction TurnLeft()
    {
        return new Direction(-Col, Row);
    }

    public Direction TurnRight()
    {
        return new Direction(Col, -Row);
    }

    public static Direction Up { get; } = new Direction(-1, 0);
    public static Direction Down { get; } = new Direction(1, 0);
    public static Direction Left { get; } = new Direction(0, -1);
    public static Direction Right { get; } = new Direction(0, 1);
}