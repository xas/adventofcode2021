namespace AdventOfCode21
{
    internal class Day07
    {
        public static void Execute()
        {
            string initCrabs = File.ReadAllText("Day07.txt");
            List<int> initPositions = initCrabs.Split(',').Select(int.Parse).ToList();
            int min = initPositions.Min();
            int max = initPositions.Max();
            int length = max - min + 1;
            var sums = Enumerable.Range(min, length).Select(x => initPositions.Sum(y => Math.Abs(y - x)));
            Console.WriteLine($"Day 07.01 : {sums.Min()}");
            sums = Enumerable.Range(min, length).Select(x => initPositions.Sum(y => Triangular(Math.Abs(y - x))));
            Console.WriteLine($"Day 07.02 : {sums.Min()}");
        }

        private static int Triangular(int sum)
        {
            return (sum * (sum + 1)) / 2;
        }
    }
}
