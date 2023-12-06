using Day05.Solvers;
using static Common.Utils;

namespace Day05
{
    internal static class Program
    {
        private const string FileName = "Day05";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 5,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 5,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}