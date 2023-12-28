namespace Day17.Solvers;

public class Position(int row, int col)
{
    public readonly int Row = row;
    public readonly int Col = col;

    public Position Move(Direction dir)
    {
        return new Position(Row + dir.Row, Col + dir.Col);
    }
}