using static Common.Utils;
using Day01.Solvers;

namespace Day01
{
    internal static class Program
    {
        private const string FileName = "Day01";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 1,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 1,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}