namespace AdventOfCode21
{
    internal static class Day01
    {
        public static void Execute()
        {
			// Day 01
			string[] measures = File.ReadAllLines("day01.txt");
			List<int> measureList = new List<int>();
			foreach (string measure in measures)
			{
				measureList.Add(Convert.ToInt32(measure));
			}
			int occurrence = 0;
			int lastRead = measureList.First();
			for (int i = 1; i < measureList.Count; i++)
			{
				if (measureList[i] > lastRead)
				{
					occurrence++;
				}
				lastRead = measureList[i];
			}
			Console.WriteLine($"Day 01.1 : {lastRead} - {occurrence}");

			occurrence = 0;
			int lastTotal = measureList[0] + measureList[1] + measureList[2];
			for (int i = 1; i < measureList.Count - 2; i++)
			{
				int currentTotal = measureList[i] + measureList[i + 1] + measureList[i + 2];
				if (currentTotal > lastTotal)
				{
					occurrence++;
				}
				lastTotal = currentTotal;
			}
			Console.WriteLine($"Day 01.2 : {lastTotal} - {occurrence}");
		}
	}
}
