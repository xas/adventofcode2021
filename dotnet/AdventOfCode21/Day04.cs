using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode21
{
    internal class Day04
    {
        public static void Execute()
        {
            string[] bingoFile = File.ReadAllLines("Day04.txt");
            List<int> draws = bingoFile[0].Split('\u002C').Select(x => Convert.ToInt32(x)).ToList();
            List<BingoCard> cards = new List<BingoCard>();
            BingoCard card = new BingoCard();
            int position = 0;
            for (int i = 2; i < bingoFile.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(bingoFile[i]))
                {
                    cards.Add(card);
                    card = new BingoCard();
                    position = 0;
                    continue;
                }
                card.AddLine(position++, bingoFile[i].Trim().Replace("  ", " ").Split(' ').Select(x => Convert.ToInt32(x)).ToArray());
            }
            foreach (int i in draws)
            {
                foreach (BingoCard bingoCard in cards)
                {
                    if (bingoCard.MarkNumber(i))
                    {
                        if (cards.All(x => x.won))
                        {
                            Console.WriteLine("Last Bingo");
                            Console.WriteLine(i * bingoCard.UnmarkedTotal());
                            return;
                        }
                    }
                }
            }
        }

        public class BingoCard
        {
            int[,] card = new int[5, 5];
            bool[,] drawn = new bool[5, 5];
            public bool won { get; private set; }

            public void AddLine(int position, int[] line)
            {
                for (int x = 0; x < card.GetLength(1); x++)
                {
                    card[position, x] = line[x];
                    drawn[position, x] = false;
                }
            }

            public bool MarkNumber(int number)
            {
                for (int i = 0; i < card.GetLength(0); i++)
                {
                    for (int j = 0; j < card.GetLength(1); j++)
                    {
                        if (number == card[i, j])
                        {
                            drawn[i, j] = true;
                            int col = Enumerable.Range(0, drawn.GetLength(0)).Where(x => drawn[x, j]).Count();
                            var row = Enumerable.Range(0, drawn.GetLength(0)).Where(x => drawn[i, x]).Count();
                            if (col == 5 || row == 5)
                            {
                                won = true;
                            }
                            return won;
                        }
                    }
                }
                return false;
            }

            public int UnmarkedTotal()
            {
                int total = 0;
                for (int i = 0; i < card.GetLength(0); i++)
                {
                    for (int j = 0; j < card.GetLength(1); j++)
                    {
                        if (!drawn[i, j])
                        {
                            total += card[i, j];
                        }
                    }
                }
                return total;
            }
        }
    }
}
