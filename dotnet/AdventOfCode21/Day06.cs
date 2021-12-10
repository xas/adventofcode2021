namespace AdventOfCode21
{
    internal class Day06
    {
        public static void Execute()
        {
            string initState = File.ReadAllText("Day06.txt");
            long[] lanternfish = new long[9];
            initState.Split(',').ToList().ForEach(x => lanternfish[Convert.ToInt32(x)]++);
            for (int currentDay = 0; currentDay < 80; currentDay++)
            {
                long newFish = lanternfish[0];
                for (int j = 0; j < 8; j++)
                    lanternfish[j] = lanternfish[j + 1];
                lanternfish[6] += newFish;
                lanternfish[8] = newFish;
            }
            long total = lanternfish.Sum(x => x);
            Console.WriteLine($"Day 06.01 : {total}");

            for (int currentDay = 80; currentDay < 256; currentDay++)
            {
                long newFish = lanternfish[0];
                for (int j = 0; j < 8; j++)
                    lanternfish[j] = lanternfish[j + 1];
                lanternfish[6] += newFish;
                lanternfish[8] = newFish;
            }
            total = lanternfish.Sum(x => x);
            Console.WriteLine($"Day 06.02 : {total}");
        }
    }
}
