using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode21
{
    internal class Day05
    {
        public static void Execute()
        {
            string[] lines = File.ReadAllLines("Day05.txt");

            List<Vector> vectorsPartOne = new List<Vector>();
            List<Vector> vectorsPartTwo = new List<Vector>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(" -> ");
                Vector vector = new Vector(parts[0].Split(',').Select(x => Convert.ToInt32(x)),
                                            parts[1].Split(',').Select(x => Convert.ToInt32(x)));
                if (vector.IsSameLine())
                    vectorsPartOne.Add(vector);
                else
                    vectorsPartTwo.Add(vector);
            }
            int[,] overlap = new int[1000, 1000];
            foreach (Vector vector in vectorsPartOne)
            {
                for (int i = vector.Start.X; i <= vector.End.X; i++)
                {
                    for (int j = vector.Start.Y; j <= vector.End.Y; j++)
                    {
                        overlap[i, j]++;
                    }
                }
            }

            int total = 0;
            for (int i = 0; i < overlap.GetLength(0); i++)
            {
                for (int j = 0; j < overlap.GetLength(1); j++)
                {
                    if (overlap[i, j] > 1)
                    {
                        total++;
                    }
                }
            }
            Console.WriteLine($"Day 05.01 : {total}"); //7438

            total = 0;
            foreach (Vector vector in vectorsPartTwo)
            {
                int xStep = vector.V1.X == vector.V2.X ? 0 : vector.V1.X > vector.V2.X ? -1 : 1;
                int yStep = vector.V1.Y == vector.V2.Y ? 0 : vector.V1.Y > vector.V2.Y ? -1 : 1;
                for (int i = vector.V1.X, j = vector.V1.Y; i != vector.V2.X && j != vector.V2.Y; i+=xStep, j+=yStep)
                {
                    overlap[i, j]++;
                }
                overlap[vector.V2.X, vector.V2.Y]++;
            }
            for (int i = 0; i < overlap.GetLength(0); i++)
            {
                for (int j = 0; j < overlap.GetLength(1); j++)
                {
                    if (overlap[i, j] > 1)
                    {
                        total++;
                    }
                }
            }
            Console.WriteLine($"Day 05.02 : {total}"); //21406
        }

        public class Vector
        {
            public Point V1 { get; private set; }
            public Point V2 { get; private set; }

            public Point Start => new Point(Math.Min(V1.X, V2.X), Math.Min(V1.Y, V2.Y));
            public Point End => new Point(Math.Max(V1.X, V2.X), Math.Max(V1.Y, V2.Y));

            public Vector(IEnumerable<int> start, IEnumerable<int> end)
            {
                V1 = new Point(start.ElementAt(0), start.ElementAt(1));
                V2 = new Point(end.ElementAt(0), end.ElementAt(1));
            }

            public bool IsSameLine()
            {
                return V1.X == V2.X || V1.Y == V2.Y;
            }
        }
    }
}
