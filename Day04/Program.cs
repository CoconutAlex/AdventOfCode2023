﻿using Day04.Solvers;
using static Common.Utils;

namespace Day04
{
    internal static class Program
    {
        private const string FileName = "Day04";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 4,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 4,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}