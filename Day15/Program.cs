using Day15.Solvers;
using static Common.Utils;

namespace Day15
{
    internal static class Program
    {
        private const string FileName = "Day15";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 15,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 15,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}