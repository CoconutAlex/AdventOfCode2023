using Common;

namespace Day14.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        CharGrid platform = ParseInput(lines);
        int totalLoad = CalculateTotalLoad(platform);

        return totalLoad.ToString();
    }

    private static int CalculateTotalLoad(CharGrid platform)
    {
        bool didSlide;

        do
        {
            didSlide = false;

            for (int row = 1; row < platform.Height; row++)
            {
                for (int col = 0; col < platform.Width; col++)
                {
                    Position pos = new Position(row, col);

                    if (platform.At(pos) == "O" && platform.At(pos.Up()) == ".")
                    {
                        platform.Set(pos.Up(), "O");
                        platform.Set(pos, ".");
                        didSlide = true;
                    }
                }
            }
        } while (didSlide);

        int totalLoad = 0;

        for (int row = 0; row < platform.Height; row++)
        {
            for (int col = 0; col < platform.Width; col++)
            {
                if (platform.At(new Position(row, col)) == "O")
                {
                    totalLoad += platform.Height - row;
                }
            }
        }

        return totalLoad;
    }

    private static CharGrid ParseInput(IEnumerable<string> lines)
    {
        return new CharGrid(lines);
    }
}