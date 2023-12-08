namespace Common
{
    public static class Utils
    {
        private const string InputFolderPath = @"C:\MyCode\AdventOfCode2023\Common\InputPuzzles/";

        #region Base

        public static void ExecuteSafely(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception)
            {
                Console.WriteLine("An exception occured: ");
                throw;
            }
        }

        public static void DisplayResults(Solver solution)
        {
            if (solution.Part == 1)
                Console.WriteLine($"\n--- Day {solution.Day}: {solution.Title} ---\n");

            Console.WriteLine($"Part {solution.Part}: {solution.Result}");
        }

        public static string GetTitle(string[] args)
        {
            return args.Length > 0 ? string.Join(" ", args) : "Empty Title..";
        }

        #endregion

        #region InputFile

        private static string GetInputFilePath(string fileName)
        {
            return $"{InputFolderPath}/{fileName}.txt";
        }

        public static string[] GetInputLines(string fileName)
        {
            return File.ReadAllLines(GetInputFilePath(fileName));
        }

        public static IReadOnlyList<string> RemoveEmptyLines(IEnumerable<string> input)
        {
            return input.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }

        #endregion

        #region LCM

        public static long CalculateLcm(IReadOnlyList<long> numbers)
        {
            if (numbers.Count < 2)
            {
                throw new ArgumentException("At least two numbers are required to calculate LCM.");
            }

            long lcm = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                lcm = CalculateLcm(lcm, numbers[i]);
            }

            return lcm;
        }

        private static long CalculateLcm(long a, long b)
        {
            return Math.Abs(a * b) / CalculateGcd(a, b);
        }

        private static long CalculateGcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return Math.Abs(a);
        }

        #endregion
    }
}