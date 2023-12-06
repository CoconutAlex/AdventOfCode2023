using Common;
using System.Text.RegularExpressions;

namespace Day01.Solvers
{
    public sealed class Part02 : Solver
    {
        private const string Pattern = @"\d+|one|two|three|four|five|six|seven|eight|nine";

        protected override string Resolve(string[] lines)
        {
            int totalSum = 0;

            foreach (string line in lines)
            {
                int firstDigit = GetFirstDigit(line);
                int lastDigit = GetLastDigit(line);

                int calibrationValue = firstDigit * 10 + lastDigit;

                totalSum += calibrationValue;
            }

            return totalSum.ToString();
        }

        private static int GetFirstDigit(string input)
        {
            Match match = Regex.Match(input, Pattern);

            if (match.Success)
            {
                if (int.TryParse(match.Value, out int numericValue))
                {
                    if (numericValue > 9)
                    {
                        string numericValueStr = numericValue.ToString();
                        numericValue = int.Parse(numericValueStr[0].ToString());
                    }

                    return numericValue;
                }

                return GetSpelledDigitValue(match.Value);
            }

            return 0;
        }

        private static int GetLastDigit(string input)
        {
            MatchCollection matches = new Regex(Pattern).Matches(input);

            if (matches.Count > 0)
            {
                if (int.TryParse(matches[matches.Count - 1].Value, out int numericValue))
                {
                    if (numericValue > 9)
                    {
                        string numericValueStr = numericValue.ToString();
                        numericValue = int.Parse(numericValueStr[numericValueStr.Length - 1].ToString());
                    }

                    return numericValue;
                }
                else
                {
                    return GetSpelledDigitValue(matches[matches.Count - 1].Value);
                }
            }

            return 0;
        }

        private static int GetSpelledDigitValue(string spelledDigit)
        {
            return spelledDigit.ToLower() switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => -1
            };
        }
    }
}