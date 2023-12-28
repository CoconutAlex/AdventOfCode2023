namespace Day14.Solvers;

public class CharGrid
{
    private readonly List<List<char>> grid;
    public int Width { get; private set; }
    public int Height { get; private set; }

    public CharGrid(IEnumerable<string> lines)
    {
        grid = lines.Select(line => line.ToList()).ToList();
        Height = grid.Count;
        Width = grid.Max(row => row.Count);
    }

    public string At(Position pos)
    {
        return Convert.ToString(pos.Row < Height && pos.Col < grid[pos.Row].Count ? grid[pos.Row][pos.Col] : null);
    }

    public void Set(Position pos, string value)
    {
        if (pos.Row < Height && pos.Col < grid[pos.Row].Count)
        {
            grid[pos.Row][pos.Col] = Convert.ToChar(value);
        }
    }

    public bool Contains(Position pos)
    {
        return pos.Row >= 0 && pos.Row < Height && pos.Col >= 0 && pos.Col < Width;
    }

    public bool Eq(List<string> dump)
    {
        return grid.Zip(dump, (row, dumpRow) => row.SequenceEqual(dumpRow)).All(x => x);
    }

    public List<List<char>> Dump()
    {
        return grid.Select(row => row.ToList()).ToList();
    }
}