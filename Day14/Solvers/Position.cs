namespace Day14.Solvers;

public class Position
{
    public readonly int Row;
    public readonly int Col;

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public Position Clone()
    {
        return new Position(Row, Col);
    }

    public Position Up()
    {
        return new Position(Row - 1, Col);
    }

    public Position Down()
    {
        return new Position(Row + 1, Col);
    }

    public Position Left()
    {
        return new Position(Row, Col - 1);
    }

    public Position Right()
    {
        return new Position(Row, Col + 1);
    }

    public Position Move(Direction dir)
    {
        return new Position(Row + dir.Row, Col + dir.Col);
    }
}