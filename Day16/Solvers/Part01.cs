using Common;

namespace Day16.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalTiles = CalculateTotalTiles(lines);

        return totalTiles.ToString();
    }

    private static int CalculateTotalTiles(string[] input)
    {
        char[][] grid = Array.ConvertAll(input, line => line.ToCharArray());

        State state = new State(0, 0, "right", new HashSet<string>());

        HashSet<string> energized = new HashSet<string>();

        Step(state);
        Render(grid, energized);

        return energized.Count;

        void Step(State state)
        {
            if (IsOutOfBounds(state, grid))
                return;

            int x = state.X, y = state.Y;
            string direction = state.Direction;
            string key = $"{x},{y},{direction}";

            if (state.Seen.Contains(key)) return;

            state.Seen.Add(key);
            energized.Add($"{x},{y}");

            switch (grid[y][x])
            {
                case '.':
                    Step(Move(state));
                    break;
                case '|':
                    switch (direction)
                    {
                        case "up":
                        case "down":
                            Step(Move(state));
                            break;
                        case "left":
                        case "right":
                            Step(Move(new State(x, y, "up", state.Seen)));
                            Step(Move(new State(x, y, "down", state.Seen)));
                            break;
                    }

                    break;
                case '-':
                    switch (direction)
                    {
                        case "left":
                        case "right":
                            Step(Move(state));
                            break;
                        case "up":
                        case "down":
                            Step(Move(new State(x, y, "left", state.Seen)));
                            Step(Move(new State(x, y, "right", state.Seen)));
                            break;
                    }

                    break;
                case '/':
                    switch (direction)
                    {
                        case "up":
                            Step(Move(new State(x, y, "right", state.Seen)));
                            break;
                        case "down":
                            Step(Move(new State(x, y, "left", state.Seen)));
                            break;
                        case "left":
                            Step(Move(new State(x, y, "down", state.Seen)));
                            break;
                        case "right":
                            Step(Move(new State(x, y, "up", state.Seen)));
                            break;
                    }

                    break;
                case '\\':
                    switch (direction)
                    {
                        case "up":
                            Step(Move(new State(x, y, "left", state.Seen)));
                            break;
                        case "down":
                            Step(Move(new State(x, y, "right", state.Seen)));
                            break;
                        case "left":
                            Step(Move(new State(x, y, "up", state.Seen)));
                            break;
                        case "right":
                            Step(Move(new State(x, y, "down", state.Seen)));
                            break;
                    }

                    break;
            }
        }
    }

    private static State Move(State state)
    {
        int x = state.X, y = state.Y;
        string direction = state.Direction;

        return direction switch
        {
            "up" => new State(x, y - 1, direction, state.Seen),
            "down" => new State(x, y + 1, direction, state.Seen),
            "left" => new State(x - 1, y, direction, state.Seen),
            "right" => new State(x + 1, y, direction, state.Seen),
            _ => throw new ArgumentException("Invalid direction")
        };
    }

    private static void Render(IReadOnlyList<char[]> grid, IReadOnlySet<string> energized)
    {
        for (int y = 0; y < grid.Count; y++)
        {
            string row = string.Empty;
            for (int x = 0; x < grid[0].Length; x++)
            {
                row += energized.Contains($"{x},{y}") ? '#' : grid[y][x];
            }
        }
    }

    private static bool IsOutOfBounds(State state, IReadOnlyList<char[]> grid)
    {
        return state.X < 0 || state.Y < 0 || state.Y >= grid.Count || state.X >= grid[0].Length;
    }
}