namespace Common
{
    public static class Utils
    {
        private const string InputFolderPath = "../Common/InputPuzzles/";

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

        public static string[] GetInputLines(string fileName)
        {
            return File.ReadAllLines(GetInputFilePath(fileName));
        }

        public static IReadOnlyList<string> RemoveEmptyLines(IEnumerable<string> input)
        {
            return input.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }

        private static string GetInputFilePath(string fileName)
        {
            return $"{InputFolderPath}/{fileName}.txt";
        }

        public static string GetTitle(string[] args)
        {
            return args.Length > 0 ? string.Join(" ", args) : "Empty Title..";
        }

        public static void DisplayResults(Solver solution)
        {
            if (solution.Part == 1)
                Console.WriteLine($"\n--- Day {solution.Day}: {solution.Title} ---\n");

            Console.WriteLine($"Part {solution.Part}: {solution.Result}");
        }
    }
}