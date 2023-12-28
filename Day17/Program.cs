using Day17.Solvers;
using static Common.Utils;

namespace Day17
{
    internal static class Program
    {
        private const string FileName = "Day17";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 17,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 17,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}