﻿using Day09.Solvers;
using static Common.Utils;

namespace Day09
{
    internal static class Program
    {
        private const string FileName = "Day09";

        private static void Main(string[] args)
        {
            ExecuteSafely(() =>
            {
                new Part01
                {
                    Title = GetTitle(args),
                    Day = 9,
                    Part = 1,
                    FileInputName = FileName
                }.RunSolver();

                new Part02
                {
                    Day = 9,
                    Part = 2,
                    FileInputName = FileName
                }.RunSolver();
            });
        }
    }
}