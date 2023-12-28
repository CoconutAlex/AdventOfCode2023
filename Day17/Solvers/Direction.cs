namespace Day17.Solvers;

public class Direction(int row, int col)
{
    public readonly int Row = row;
    public readonly int Col = col;

    public Direction TurnLeft()
    {
        return new Direction(-Col, Row);
    }

    public Direction TurnRight()
    {
        return new Direction(Col, -Row);
    }

    public static Direction Up = new(-1, 0);
    public static Direction Down = new(1, 0);
    public static Direction Left = new(0, -1);
    public static Direction Right = new(0, 1);
}