using Day21.Solvers;
using static Common.Utils;

namespace Day21
{
    internal static class Program
    {
        private const string FileName = "Day21";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 21,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();
 
                new Part02
                {
                    Day = 21,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}