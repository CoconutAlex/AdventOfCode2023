using Common;

namespace Day09.Solvers;

public sealed class Part01 : Solver
{
    protected override string Resolve(string[] lines)
    {
        int sumExtrapolated  = CalculateSumExtrapolated(lines);

        return sumExtrapolated .ToString();
    }

    private static int CalculateSumExtrapolated(IEnumerable<string> input)
    {
        List<List<int>> sequence = input.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
        
        int total = FindTotal(sequence);
        
        return total;
    }
    
    private static int FindTotal(IEnumerable<List<int>> arrOfArrays)
    {
        return arrOfArrays.Sum(array => FindHistory(array));
    }
    
    private static int FindHistory(List<int> currentArray)
    {
        List<List<int>> allArrays = new List<List<int>> { currentArray };

        Helpers.FindNextArr(currentArray,allArrays);
        
        return allArrays.Sum(innerArr => innerArr.Last());
    }
}