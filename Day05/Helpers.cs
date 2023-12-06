namespace Day05;

public static class Helpers
{
    public static long[] GetSeeds(string lines)
    {
        return lines
            .Split("seeds: ")[1]
            .Split(' ')
            .Select(seed => long.Parse(seed))
            .ToArray();
    }

    public static (List<long[]>, List<long[]>, List<long[]>, List<long[]>, List<long[]>, List<long[]>, List<long[]>)
        CreateRestLists(IEnumerable<string> lines)
    {
        List<long[]> seedToSoilMap = new List<long[]>();
        List<long[]> soilToFertilizerMap = new List<long[]>();
        List<long[]> fertilizerToWaterMap = new List<long[]>();
        List<long[]> waterToLightMap = new List<long[]>();
        List<long[]> lightToTemperatureMap = new List<long[]>();
        List<long[]> temperatureToHumidityMap = new List<long[]>();
        List<long[]> humidityToLocationMap = new List<long[]>();

        var maps = new Dictionary<string, List<long[]>>
        {
            { "seed-to-soil", seedToSoilMap },
            { "soil-to-fertilizer", soilToFertilizerMap },
            { "fertilizer-to-water", fertilizerToWaterMap },
            { "water-to-light", waterToLightMap },
            { "light-to-temperature", lightToTemperatureMap },
            { "temperature-to-humidity", temperatureToHumidityMap },
            { "humidity-to-location", humidityToLocationMap }
        };

        var stringBlock = string.Empty;

        foreach (var line in lines.Skip(1))
        {
            if (maps.ContainsKey(line.Split(' ')[0].Trim()))
            {
                stringBlock = line.Split(' ')[0].Trim();
                continue;
            }

            AddMapToDictionary(maps[stringBlock], line);
        }

        return (seedToSoilMap, soilToFertilizerMap, fertilizerToWaterMap, waterToLightMap, lightToTemperatureMap,
            temperatureToHumidityMap, humidityToLocationMap);
    }

    public static long MapSeedToCategory(long seed, IEnumerable<long[]> map)
    {
        foreach (var entry in map)
        {
            if (seed >= entry[1] && seed < entry[1] + entry[2])
            {
                return entry[0] + (seed - entry[1]);
            }
        }

        return seed;
    }

    public static long MapCategoryToCategory(long category, IEnumerable<long[]> map)
    {
        foreach (var entry in map)
        {
            if (category >= entry[1] && category < entry[1] + entry[2])
            {
                return entry[0] + (category - entry[1]);
            }
        }

        return category;
    }

    private static void AddMapToDictionary(List<long[]> mapList, string line)
    {
        mapList.Add(line.Split(' ')
            .Select(seed => long.Parse(seed))
            .ToArray());
    }
}