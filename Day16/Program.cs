using Day16.Solvers;
using static Common.Utils;

namespace Day16
{
    internal static class Program
    {
        private const string FileName = "Day16";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 16,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 16,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}