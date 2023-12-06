using Day03.Solvers;
using static Common.Utils;

namespace Day03
{
    internal static class Program
    {
        private const string FileName = "Day03";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 3,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 3,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}