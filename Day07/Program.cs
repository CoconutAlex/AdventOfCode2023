using Day07.Solvers;
using static Common.Utils;

namespace Day07
{
    internal static class Program
    {
        private const string FileName = "Day07";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 6,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 6,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}