namespace AdventOfCode21
{
    internal static class Day02
    {
        public static void Execute()
        {
			string[] completeMoves = File.ReadAllLines("day02.txt");
			int depth = 0;
			int aim = 0;
			int horizon = 0;
			for (int i = 0; i < completeMoves.Length; i++)
			{
				string[] command = completeMoves[i].Split(' ');
				int step = Convert.ToInt32(command[1]);
				switch (command[0])
				{
					case "forward":
						horizon += step;
						depth += step * aim;
						break;
					case "up":
						aim -= step;
						break;
					case "down":
						aim += step;
						break;
				}
			}
			Console.WriteLine($"Day 02.01 : depth = {depth} - horizon = {horizon}");
			Console.WriteLine($"Day 02.02 : aim = {aim} for {depth * horizon}");
		}
	}
}
