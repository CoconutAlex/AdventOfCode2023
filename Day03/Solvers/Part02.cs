using Common;

namespace Day03.Solvers;

public sealed class Part02 : Solver
{
    private const char GearSymbol = '*';

    protected override string Resolve(string[] lines)
    {
        long partNumberSum = CalculateGearRatioSum(lines);

        return partNumberSum.ToString();
    }

    private static long CalculateGearRatioSum(IReadOnlyList<string> engineSchematic)
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

        return GetListOfGearRatio(table, rows, columns).Sum();
    }

    private static IEnumerable<int> GetListOfGearRatio(char[,] table, int rows, int columns)
    {
        List<int> gearRatioList = new List<int>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (!table[i, j].Equals(GearSymbol)) continue;

                NumberInfo numberInfo = new NumberInfo();

                List<int> saveNumbers = new List<int>();

                //1st Check
                if (j - 1 >= 0 && char.IsDigit(table[i, j - 1]))
                {
                    numberInfo.Value = table[i, j - 1] + numberInfo.Value;
                    numberInfo.SetIndexes(j - 1, j - 1);

                    if (j - 2 >= 0 && char.IsDigit(table[i, j - 2]))
                    {
                        numberInfo.Value = table[i, j - 2] + numberInfo.Value;
                        numberInfo.SetIndexes(j - 2, j - 1);

                        if (j - 3 >= 0 && char.IsDigit(table[i, j - 3]))
                        {
                            numberInfo.Value = table[i, j - 3] + numberInfo.Value;
                            numberInfo.SetIndexes(j - 3, j - 1);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(numberInfo.Value))
                {
                    saveNumbers.Add(int.Parse(numberInfo.Value));
                }

                numberInfo = new NumberInfo();

                //2nd Check
                if (j + 1 <= columns - 1 && char.IsDigit(table[i, j + 1]))
                {
                    numberInfo.Value += table[i, j + 1];
                    numberInfo.SetIndexes(j + 1, j + 1);

                    if (j + 2 <= columns - 1 && char.IsDigit(table[i, j + 2]))
                    {
                        numberInfo.Value += table[i, j + 2];
                        numberInfo.SetIndexes(j + 1, j + 2);

                        if (j + 3 <= columns - 1 && char.IsDigit(table[i, j + 3]))
                        {
                            numberInfo.Value += table[i, j + 3];
                            numberInfo.SetIndexes(j + 1, j + 3);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(numberInfo.Value))
                {
                    saveNumbers.Add(int.Parse(numberInfo.Value));
                }

                //3rd Check
                char[] tempArrayUp = new char[7];

                for (int u = j - 3, index = 0; u <= j + 3; u++, index++)
                {
                    if (u >= 0 && u < table.GetLength(1))
                    {
                        tempArrayUp[index] = table[i - 1, u];
                    }
                }

                List<NumberInfo> possibleNumbersUpRow = FindNumbers(tempArrayUp);
                foreach (var possibleNumber in possibleNumbersUpRow)
                {
                    if (possibleNumber.StartIndex + j - 3 == j + 1 || possibleNumber.StartIndex + j - 3 == j ||
                        possibleNumber.StartIndex + j - 3 == j - 1 || possibleNumber.EndIndex + j - 3 == j - 1 ||
                        possibleNumber.EndIndex + j - 3 == j || possibleNumber.EndIndex + j - 3 == j + 1)
                    {
                        saveNumbers.Add(int.Parse(possibleNumber.Value));
                    }
                }

                //4th Check
                char[] tempArrayDown = new char[7];

                for (int d = j - 3, index = 0; d <= j + 3; d++, index++)
                {
                    if (d >= 0 && d < table.GetLength(1))
                    {
                        tempArrayDown[index] = table[i + 1, d];
                    }
                }

                List<NumberInfo> possibleNumbersDownRow = FindNumbers(tempArrayDown);
                foreach (var possibleNumber in possibleNumbersDownRow)
                {
                    if (possibleNumber.StartIndex + j - 3 == j + 1 || possibleNumber.StartIndex + j - 3 == j ||
                        possibleNumber.StartIndex + j - 3 == j - 1 || possibleNumber.EndIndex + j - 3 == j - 1 ||
                        possibleNumber.EndIndex + j - 3 == j || possibleNumber.EndIndex + j - 3 == j + 1)
                    {
                        saveNumbers.Add(int.Parse(possibleNumber.Value));
                    }
                }

                if (saveNumbers.Count == 1) continue;
                if (saveNumbers.Count > 2) Console.WriteLine("Houston, we have a problem!");

                gearRatioList.Add(saveNumbers[0] * saveNumbers[1]);
            }
        }

        return gearRatioList;
    }

    private static List<NumberInfo> FindNumbers(char[] inputArray)
    {
        List<NumberInfo> numbers = new List<NumberInfo>();
        int startIndex = -1;

        for (int i = 0; i < inputArray.Length; i++)
        {
            if (char.IsDigit(inputArray[i]))
            {
                if (startIndex == -1)
                {
                    startIndex = i;
                }
            }
            else
            {
                if (startIndex == -1) continue;
                int endIndex = i - 1;
                string numberValue = new string(inputArray, startIndex, endIndex - startIndex + 1);
                numbers.Add(new NumberInfo(numberValue, startIndex, endIndex));
                startIndex = -1;
            }
        }

        if (startIndex != -1)
        {
            int endIndex = inputArray.Length - 1;
            string numberValue = new string(inputArray, startIndex, endIndex - startIndex + 1);
            numbers.Add(new NumberInfo(numberValue, startIndex, endIndex));
        }

        return numbers;
    }
}