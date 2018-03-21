using System;
using System.Collections.Generic;
using System.Linq;

namespace All_Paths_In_Labyrinth
{
    class Program
    {
        private static char[,] lab;
        private static List<char> path = new List<char>();
        private static int row;
        private static int col;

        private static void Main(string[] args)
        {
            lab = GetLabyrinth();
            FindExit(0, 0, 'S');
        }

        private static void FindExit(int row, int col, char direction)
        {
            if (!isInBoundries(row, col))
            {
                return;
            }

            path.Add(direction);
            if (onExit(row, col))
            {
                PrintPath();
            }
            else if (!isVisited(row, col) && isFree(row, col))
            {
                Mark(row, col);
                FindExit(row, col + 1, 'R');
                FindExit(row + 1, col, 'D');
                FindExit(row, col - 1, 'L');
                FindExit(row - 1, col, 'U');
                Unmark(row, col);
            }
            path.RemoveAt(path.Count - 1);
        }

        private static void Unmark(int row, int col)
        {
            lab[row, col] = '-';
        }

        private static void Mark(int row, int col)
        {
            lab[row, col] = '+';
        }

        private static bool isFree(int row, int col)
        {
            return lab[row, col] == '-';
        }

        private static bool isVisited(int row, int col)
        {
            return lab[row, col] == '+';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        private static bool isInBoundries(int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentRow < row &&
                  currentCol < col && currentCol >= 0;
        }

        private static bool onExit(int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static char[,] GetLabyrinth()
        {
            int rowInput = int.Parse(Console.ReadLine());
            int colInput = int.Parse(Console.ReadLine());

            row = rowInput;
            col = colInput;

            char[,] lab = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var labLine = Console.ReadLine();

                var line = labLine.ToCharArray();

                for (int j = 0; j < line.Length; j++)
                {
                    lab[i, j] = line[j];
                }
            }

            return lab;
        }
    }
}