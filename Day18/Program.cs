using Day18.Solvers;
using static Common.Utils;

namespace Day18
{
    internal static class Program
    {
        private const string FileName = "Day18";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 18,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 18,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}