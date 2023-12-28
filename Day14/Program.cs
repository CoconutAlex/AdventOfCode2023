using Day14.Solvers;
using static Common.Utils;

namespace Day14
{
    internal static class Program
    {
        private const string FileName = "Day14";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 14,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 14,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}