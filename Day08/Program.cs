using Day08.Solvers;
using static Common.Utils;

namespace Day08
{
    internal static class Program
    {
        private const string FileName = "Day08";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 8,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 8,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}