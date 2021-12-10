namespace AdventOfCode21
{
    internal static class Day03
    {
        public static void Execute()
        {
            string[] bits = File.ReadAllLines("Day03.txt");
            int[] zeroes = new int[12];
            int[] ones = new int[12];
            for (int i = 0; i < 12; i++)
            {
                zeroes[i] = bits.Where(x => x[i] == '0').Count();
                ones[i] = bits.Where(x => x[i] == '1').Count();
            }

            int gamma = 0;
            int epsilon = 0;
            for (int i = 0; i < 12; i++)
            {
                if (ones[i] > zeroes[i])
                {
                    gamma |= (1 << (11 - i));
                }
                else
                {
                    epsilon |= (1 << (11 - i));
                }
            }
            Console.WriteLine($"Day 03.01 : {gamma * epsilon}");

            // Part 02
            List<string> o2 = new List<string>(bits);
            List<string> co2 = new List<string>(bits);
            int[] O2zeroes = new int[12];
            int[] O2ones = new int[12];
            int[] CO2zeroes = new int[12];
            int[] CO2ones = new int[12];
            for (int i = 0; i < 12; i++)
            {
                O2zeroes[i] = o2.Where(x => x[i] == '0').Count();
                O2ones[i] = o2.Where(x => x[i] == '1').Count();
                CO2zeroes[i] = co2.Where(x => x[i] == '0').Count();
                CO2ones[i] = co2.Where(x => x[i] == '1').Count();
                if (O2ones[i] >= O2zeroes[i])
                {
                    if (o2.Count > 1)
                    {
                        o2.RemoveAll(x => x[i] == '0');
                    }
                }
                else
                {
                    if (o2.Count > 1)
                    {
                        o2.RemoveAll(x => x[i] == '1');
                    }
                }
                if (CO2ones[i] >= CO2zeroes[i])
                {
                    if (co2.Count > 1)
                    {
                        co2.RemoveAll(x => x[i] == '1');
                    }
                }
                else
                {
                    if (co2.Count > 1)
                    {
                        co2.RemoveAll(x => x[i] == '0');
                    }
                }
            }
            int oxygen = Convert.ToInt32(o2.First(), 2);
            int dioxygen = Convert.ToInt32(co2.First(), 2);
            Console.WriteLine($"Day 03.02 : {oxygen * dioxygen}");
        }
    }
}
