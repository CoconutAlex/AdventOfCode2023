using Day02.Solvers;
using static Common.Utils;

namespace Day02
{
    internal static class Program
    {
        private const string FileName = "Day02";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 2,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 2,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}