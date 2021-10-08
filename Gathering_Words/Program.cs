using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Diagnostics;

namespace Gathering_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rndNumbers = new Random();

            Console.Write("Welcome to Words Gathering! Press Enter to play:");
            Console.WriteLine();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Player player = new Player("&");
            DictionaryOfWords listOfAllWords = new DictionaryOfWords();

            object[,] matrix = new object[15, 17];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == 4 && col == 3)
                    {
                        matrix[row, col] = player.Symbol;
                    }
                    else
                    {
                        matrix[row, col] = " ";
                    }

                    if (matrix[matrix.GetLength(0) - 1, col] == matrix[row, col])
                    {
                        matrix[row, col] = "_";
                    }
                    if (matrix[row, matrix.GetLength(1) - 1] == matrix[row, col])
                    {
                        matrix[row, col] = "|";
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            int rndWord = rndNumbers.Next(0,listOfAllWords.Words.Count);

            string randomWordSelector = listOfAllWords.Words[rndWord];

            string seekingWord = randomWordSelector;
            StringBuilder sb = new StringBuilder();

            while (sb.ToString() != seekingWord)
            {
                Falling_Words words = new Falling_Words("*");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (!IsInsideTheTable(matrix, row, col - 1))
                            {
                                continue;
                            }
                            if (IsInsideTheTable(matrix, row, col) && matrix[row, col] == player.Symbol)
                            {
                                if (matrix[row, col - 1] != " " && matrix[row, col - 1] != "|" && matrix[row, col - 1] != "_")
                                {
                                    sb.Append(matrix[row, col - 1]);
                                }

                                matrix[row, col - 1] = player.Symbol;
                                matrix[row, col] = " ";
                                if (matrix[matrix.GetLength(0) - 1, col] == " ")
                                {
                                    matrix[row, col] = "_";
                                }
                                if (matrix[row, matrix.GetLength(1) - 1] == " ")
                                {
                                    matrix[row, col] = "|";
                                }
                            }
                        }
                    }
                }
                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            if (!IsInsideTheTable(matrix, row, col + 1))
                            {
                                continue;
                            }
                            if (IsInsideTheTable(matrix, row, col) && matrix[row, col] == player.Symbol)
                            {
                                if (matrix[row, col + 1] != " " && matrix[row, col + 1] != "|" && matrix[row, col + 1] != "_")
                                {
                                    sb.Append(matrix[row, col + 1]);
                                }

                                matrix[row, col + 1] = player.Symbol;
                                matrix[row, col] = " ";

                                if (matrix[matrix.GetLength(0) - 1, col] == " ")
                                {
                                    matrix[row, col] = "_";
                                }
                                if (matrix[row, matrix.GetLength(1) - 1] == " ")
                                {
                                    matrix[row, col] = "|";
                                }
                            }
                        }
                    }
                }
                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (!IsInsideTheTable(matrix, row - 1, col))
                            {
                                continue;
                            }
                            if (IsInsideTheTable(matrix, row, col) && matrix[row, col] == player.Symbol)
                            {
                                if (matrix[row - 1, col] != " " && matrix[row - 1, col] != "|" && matrix[row - 1, col] != "_")
                                {
                                    sb.Append(matrix[row - 1, col]);
                                }

                                matrix[row - 1, col] = player.Symbol;
                                matrix[row, col] = " ";

                                if (matrix[matrix.GetLength(0) - 1, col] == " ")
                                {
                                    matrix[row, col] = "_";
                                }
                                if (matrix[row, matrix.GetLength(1) - 1] == " ")
                                {
                                    matrix[row, col] = "|";
                                }
                            }
                        }
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            if (!IsInsideTheTable(matrix, row + 1, col))
                            {
                                continue;
                            }
                            if (IsInsideTheTable(matrix, row, col) && matrix[row, col] == player.Symbol)
                            {
                                if (matrix[row + 1, col] != " " && matrix[row + 1, col] != "|" && matrix[row + 1, col] != "_")
                                {
                                    sb.Append(matrix[row + 1, col]);
                                }
                                matrix[row + 1, col] = player.Symbol;
                                matrix[row, col] = " ";

                                if (matrix[matrix.GetLength(0) - 1, col] == " ")
                                {
                                    matrix[row, col] = "_";
                                }
                                if (matrix[row, matrix.GetLength(1) - 1] == " ")
                                {
                                    matrix[row, col] = "|";
                                }
                            }
                        }
                    }
                }
                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (sb.Length != 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }

                Console.Clear();
                Console.WriteLine("-----------------");
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == "&")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(matrix[row, col]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(matrix[row, col]);
                        }

                    }
                    Console.WriteLine();
                }

                int rndRow = rndNumbers.Next(0, 14);
                int rndCol = rndNumbers.Next(1, 16);

                if (matrix[rndRow, rndCol] == player.Symbol)
                {
                    continue;
                }
                matrix[rndRow, rndCol] = words.Char;

                Console.Write($"{Environment.NewLine}You are looking for the Word: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{seekingWord}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{sb}");
                Console.ResetColor();
            }
            stopWatch.Stop();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Environment.NewLine}Congratulations! You collected all letters!");
            Console.WriteLine();
            Console.ResetColor();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Your RunTime: " + elapsedTime);
            Console.WriteLine("--------------------------");
        }
        private static bool IsInsideTheTable(object[,] matrix, int row, int col)
        {
            return row < matrix.GetLength(0) && row >= 0 && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
