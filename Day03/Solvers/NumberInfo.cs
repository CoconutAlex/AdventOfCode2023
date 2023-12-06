namespace Day03.Solvers;

public class NumberInfo
{
    public string Value { get; set; }
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }

    public NumberInfo()
    {
        Value = string.Empty;
        StartIndex = -1;
        EndIndex = -1;
    }

    public NumberInfo(string value, int startIndex, int endIndex)
    {
        Value = value;
        StartIndex = startIndex;
        EndIndex = endIndex;
    }

    public void SetIndexes(int startIndex, int endIndex)
    {
        StartIndex = startIndex;
        EndIndex = endIndex;
    }
}