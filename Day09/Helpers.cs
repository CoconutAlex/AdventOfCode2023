namespace Day09;

public class Helpers
{
    public static void FindNextArr(IReadOnlyList<int> innerArr, ICollection<List<int>> allArrays)
    {
        while (true)
        {
            List<int> nextArr = new List<int>();
            for (int i = 1; i < innerArr.Count; i++)
            {
                nextArr.Add(innerArr[i] - innerArr[i - 1]);
            }

            allArrays.Add(nextArr);
            if (nextArr.All(x => x == 0)) return;
            innerArr = nextArr;
        }
    }
}