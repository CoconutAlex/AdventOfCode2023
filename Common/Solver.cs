namespace Common
{
    public abstract class Solver
    {
        public required int Day { get; set; }
        public string? Title { get; set; }
        public required int Part { get; set; }
        public required string FileInputName { get; set; }
        public string? Result { get; set; }
        protected abstract string Resolve(string[] lines);

        public void RunSolver()
        {
            string[] lines = Utils.GetInputLines(FileInputName);
            Result = Resolve(lines);
            Utils.DisplayResults(this);
        }
    }
}