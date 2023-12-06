using Common;

namespace Day03.Solvers;

public sealed class Part01 : Solver
{
    private const char InvalidChar = '^';
    private static List<char> Symbols;

    protected override string Resolve(string[] lines)
    {
        Symbols = string.Concat(lines)
            .Where(c => !char.IsLetterOrDigit(c) && c != '.')
            .Distinct()
            .ToList();

        int partNumberSum = CalculatePartNumbersSum(lines);

        return partNumberSum.ToString();
    }

    private static int CalculatePartNumbersSum(IReadOnlyList<string> engineSchematic)
    {
        int rows = engineSchematic.Count;
        int columns = engineSchematic[0].Length;

        char[,] table = new char[rows, columns];

        int rowIndex = 0;
        foreach (var part in engineSchematic)
        {
            for (int j = 0; j < columns; j++)
            {
                table[rowIndex, j] = part[j];
            }

            rowIndex++;
        }

        return GetListOfValidNumbers(table, rows, columns).Sum();
    }

    private static IEnumerable<int> GetListOfValidNumbers(char[,] table, int rows, int columns)
    {
        List<int> validNumbers = new List<int>();

        for (int i = 0; i < rows; i++)
        {
            string newNumber = string.Empty;
            int startIndex = -1;
            for (int j = 0; j < columns; j++)
            {
                if (char.IsDigit((table[i, j])))
                {
                    if (string.IsNullOrEmpty(newNumber)) startIndex = j;
                    newNumber += (table[i, j]);

                    if (j < columns - 1) continue;
                }

                if (!string.IsNullOrEmpty(newNumber))
                {
                    var endIndex = j - 1;
                    if (
                        Symbols.Contains(startIndex == 0 ? InvalidChar : table[i, startIndex - 1]) ||
                        Symbols.Contains(endIndex == columns - 1 ? InvalidChar : table[i, endIndex + 1]) ||
                        Symbols.Contains(i == rows - 1 || startIndex == 0
                            ? InvalidChar
                            : table[i + 1, startIndex - 1]) ||
                        Symbols.Contains(i == rows - 1 ? InvalidChar : table[i + 1, startIndex]) ||
                        Symbols.Contains(i == rows - 1 || startIndex == columns - 1
                            ? InvalidChar
                            : table[i + 1, startIndex + 1]) ||
                        Symbols.Contains(i == 0 || startIndex == 0 ? InvalidChar : table[i - 1, startIndex - 1]) ||
                        Symbols.Contains(i == 0 ? InvalidChar : table[i - 1, startIndex]) ||
                        Symbols.Contains(i == 0 || startIndex == columns - 1
                            ? InvalidChar
                            : table[i - 1, startIndex + 1]) ||
                        Symbols.Contains(i == rows - 1 || endIndex == columns - 1
                            ? InvalidChar
                            : table[i + 1, endIndex + 1]) ||
                        Symbols.Contains(i == rows - 1 ? InvalidChar : table[i + 1, endIndex]) ||
                        Symbols.Contains(i == rows - 1 || endIndex == 0 ? InvalidChar : table[i + 1, endIndex - 1]) ||
                        Symbols.Contains(i == 0 || endIndex == columns - 1
                            ? InvalidChar
                            : table[i - 1, endIndex + 1]) ||
                        Symbols.Contains(i == 0 ? InvalidChar : table[i - 1, endIndex]) ||
                        Symbols.Contains(i == 0 || endIndex == 0 ? InvalidChar : table[i - 1, endIndex - 1])
                    )
                    {
                        validNumbers.Add(int.Parse(newNumber));
                    }
                }

                newNumber = string.Empty;
                startIndex = -1;
            }
        }

        return validNumbers;
    }
}