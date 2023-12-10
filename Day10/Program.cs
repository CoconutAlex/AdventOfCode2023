using Day10.Solvers;
using static Common.Utils;

namespace Day10
{
    internal static class Program
    {
        private const string FileName = "Day10";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 10,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 10,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}