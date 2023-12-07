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
                    Day = 7,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 7,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}