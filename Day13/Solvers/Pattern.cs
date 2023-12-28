using System.Text;

namespace Day13.Solvers;

public class Pattern
    {
        public List<string> lines = new List<string>();
        public List<string> columns = new List<string>();

        public void AppendLine(string line)
        {
            lines.Add(line);
        }

        public int GetVerticalReflectionCount()
        {
            List<int> verticalReflectionCollection = GetVerticalReflectionCollection();
            return verticalReflectionCollection.Count > 0 ? verticalReflectionCollection[0] : 0;
        }

        public int GetHorizontalReflectionCount()
        {
            List<int> horizontalReflectionCollection = GetHorizontalReflectionCollection();
            return horizontalReflectionCollection.Count > 0 ? horizontalReflectionCollection[0] : 0;
        }

        public List<int> GetVerticalReflectionCollection()
        {
            List<int> result = new List<int>();
            for (int i = 1; i < columns.Count; i++)
            {
                int width = Math.Min(i - 0, columns.Count - i);
                bool found = true;
                for (int x = 0; x < width && found; x++)
                {
                    found &= columns[i - x - 1] == columns[i + x];
                }
                if (found) result.Add(i);
            }
            return result;
        }

        public List<int> GetHorizontalReflectionCollection()
        {
            List<int> result = new List<int>();
            for (int i = 1; i < lines.Count; i++)
            {
                int height = Math.Min(i - 0, lines.Count - i);
                bool found = true;
                for (int y = 0; y < height && found; y++)
                {
                    found &= lines[i - y - 1] == lines[i + y];
                }
                if (found) result.Add(i);
            }
            return result;
        }

        public void ComputeColumns()
        {
            columns.Clear();
            for (int i = 0; i < lines[0].Length; i++)
            {
                columns.Add(new string(lines.Select(r => r[i]).ToArray()));
            }
        }

        public void Dump()
        {
            lines.ForEach(l => Console.WriteLine(l));
        }

        public void Swap(int x, int y)
        {
            char c = lines[y][x];
            StringBuilder b = new StringBuilder(lines[y]);
            b[x] = (c == '#') ? '.' : '#';
            lines[y] = b.ToString();
            ComputeColumns();
        }
    }