using Common;

namespace Day05.Solvers;

public sealed class Part02 : Solver
{
    protected override string Resolve(string[] lines)
    {
        long lowestLocationNumber = CalculateLowestLocationNumber(lines);

        return lowestLocationNumber.ToString();
    }

    private static long CalculateLowestLocationNumber(IEnumerable<string> input)
    {
        IReadOnlyList<string> nonEmptyLines = Utils.RemoveEmptyLines(input);
        
        long[] seeds = Helpers.GetSeeds(nonEmptyLines[0]);

        var restLists = Helpers.CreateRestLists(nonEmptyLines);
        
        List<long[]> seedRanges = new List<long[]>();
        for (int i = 0; i < seeds.Length; i += 2)
        {
            long startSeed = seeds[i];
            long rangeLength = seeds[i + 1];
            seedRanges.Add(new[] { startSeed, rangeLength });
        }

        long lowestLocation = long.MaxValue;
        foreach (var seedRange in seedRanges)
        {
            long startSeed = seedRange[0];
            long rangeLength = seedRange[1];

            for (int i = 0; i < rangeLength; i++)
            {
                long seed = startSeed + i;
                
                long soil = Helpers.MapSeedToCategory(seed, restLists.Item1);
                long fertilizer = Helpers.MapCategoryToCategory(soil, restLists.Item2);
                long water = Helpers.MapCategoryToCategory(fertilizer, restLists.Item3);
                long light = Helpers.MapCategoryToCategory(water, restLists.Item4);
                long temperature = Helpers.MapCategoryToCategory(light, restLists.Item5);
                long humidity = Helpers.MapCategoryToCategory(temperature, restLists.Item6);
                long location = Helpers.MapCategoryToCategory(humidity, restLists.Item7);

                lowestLocation = Math.Min(lowestLocation, location);
            }
        }

        return lowestLocation;
    }
}