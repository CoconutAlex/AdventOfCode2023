using Day12.Solvers;
using static Common.Utils;

namespace Day12
{
    internal static class Program
    {
        private const string FileName = "Day12";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 12,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();
            
                new Part02
                {
                    Day = 12,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}