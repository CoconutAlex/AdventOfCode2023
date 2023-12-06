using Common;

namespace Day01.Solvers
{
    public sealed class Part01 : Solver
    {
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
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return int.Parse(c.ToString());
                }
            }

            return 0;
        }

        private static int GetLastDigit(string input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    return int.Parse(input[i].ToString());
                }
            }

            return 0;
        }
    }
}