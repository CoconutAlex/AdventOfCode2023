namespace Day18;

public class Helpers
{
    public static double GetArea(IReadOnlyList<int> x, IReadOnlyList<int> y)
    {
        double sum = 0;
        for (int i = 0; i < x.Count - 1; i++)
        {
            sum += x[i] * y[i + 1] - x[i + 1] * y[i];
        }

        var area = sum / 2;
        return Math.Abs(area);
    }
}