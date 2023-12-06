namespace Day06;

public static class Helpers
{
    public static long CalculateValidWaysToBeatRecord(IReadOnlyList<long> raceTimes,
        IReadOnlyList<long> recordDistances)
    {
        long totalWays = 1;

        for (int i = 0; i < raceTimes.Count; i++)
        {
            long raceTime = raceTimes[i];
            long recordDistance = recordDistances[i];

            long waysToBeatRecord = CalculateValidWaysForSingleRace(raceTime, recordDistance);
            totalWays *= waysToBeatRecord;
        }

        return totalWays;
    }

    private static long CalculateValidWaysForSingleRace(long raceTime, long recordDistance)
    {
        long validWaysToBeatRecord = 0;

        for (int holdTime = 0; holdTime <= raceTime; holdTime++)
        {
            long remainingTime = raceTime - holdTime;
            long totalDistance = holdTime * remainingTime;
            ;

            if (totalDistance > recordDistance)
            {
                validWaysToBeatRecord++;
            }
        }

        return validWaysToBeatRecord;
    }
}