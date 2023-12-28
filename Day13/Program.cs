using Day13.Solvers;
using static Common.Utils;

namespace Day13
{
    internal static class Program
    {
        private const string FileName = "Day13";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 13,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();
            
                new Part02
                {
                    Day = 13,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}