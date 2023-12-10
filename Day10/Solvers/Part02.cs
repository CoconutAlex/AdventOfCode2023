using Common;

namespace Day10.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int totalTiles = CalculateTotalTiles(lines);

        return totalTiles.ToString();
    }

    private static int CalculateTotalTiles(IReadOnlyList<string> input)
    {
        var diagram = input.Select(l => l.Select(k => '.').ToArray()).ToArray();

        int x = 0;
        int y = 0;
        bool isReady = false;
        while (y < input.Count && !isReady)
        {
            while (x < input[0].Length && !isReady)
            {
                isReady = input[y][x] == 'S';
                if (!isReady) x++;
            }

            if (isReady) continue;
            
            x = 0;
            y++;
        }

        int direction = 0;
        isReady = false;
        diagram[y][x] = 'S';
        if (x < input[0].Length - 1 && "-J7".Contains(input[y][x + 1]))
        {
            direction = 1;
        }
        else if (y > 0 && "|7F".Contains(input[y - 1][x]))
        {
            direction = 2;
        }
        else if (x > 0 && "-FL".Contains(input[y][x - 1]))
        {
            direction = 3;
        }
        
        while (!isReady)
        {
            char c = '.';
            switch (direction)
            {
                case 0:
                    c = input[y + 1][x];
                    direction = c switch
                    {
                        'J' => 3,
                        'L' => 1,
                        _ => direction
                    };
                    y++;
                    break;
                case 1:
                    c = input[y][x + 1];
                    direction = c switch
                    {
                        'J' => 2,
                        '7' => 0,
                        _ => direction
                    };
                    x++;
                    break;
                case 2:
                    c = input[y - 1][x];
                    direction = c switch
                    {
                        'F' => 1,
                        '7' => 3,
                        _ => direction
                    };
                    y--;
                    break;
                case 3:
                    c = input[y][x - 1];
                    direction = c switch
                    {
                        'F' => 0,
                        'L' => 2,
                        _ => direction
                    };
                    x--;
                    break;
            }

            diagram[y][x] = c;
            isReady = c == 'S';
        }
        
        int totalTiles = 0;

        foreach (var t in diagram)
        {
            bool inside = false;
            char online = '.';
            for (int j = 0; j < diagram[0].Length; j++)
            {
                char cx = t[j];
                if ("|JLF7".Contains(cx))
                {
                    switch (cx)
                    {
                        case '|':
                            inside = !inside;
                            break;
                        case 'F':
                            online = 'F';
                            break;
                        case 'L':
                            online = 'L';
                            break;
                        case '7':
                            if (online == 'L') inside = !inside;
                            break;
                        case 'J':
                            if (online == 'F') inside = !inside;
                            break;
                    }
                }
                else if (cx == '.')
                {
                    if (inside) totalTiles++;
                }
            }
        }

        return totalTiles;
    }
}