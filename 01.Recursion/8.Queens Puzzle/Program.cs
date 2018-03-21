namespace _8.Queens_Puzzle
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const int SIZE = 8;
        private static string[,] chessboard = new string[SIZE, SIZE];
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        private static void PlaceQueen(int queen)
        {
            if (queen == SIZE)
            {
                Print();
            }

            for (int col = 0; col < SIZE; col++)
            {
                if (CanPutQueen(queen, col))
                {
                    MarkAttackingSpots(queen, col);
                    PlaceQueen(queen + 1);
                    UnmarkAttackingSpots(queen, col);
                }
            }
        }

        private static void MarkAttackingSpots(int queen, int col)
        {
            chessboard[queen, col] = "Q";
            attackedRows.Add(queen);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - queen);
            attackedRightDiagonals.Add(col + queen);
        }

        private static void UnmarkAttackingSpots(int queen, int col)
        {
            chessboard[queen, col] = "";
            attackedRows.Remove(queen);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - queen);
            attackedRightDiagonals.Remove(col + queen);
        }

        private static bool CanPutQueen(int queen, int col)
        {
            if (attackedRows.Contains(queen) ||
            attackedCols.Contains(col) ||
            attackedLeftDiagonals.Contains(col - queen) ||
            attackedRightDiagonals.Contains(col + queen))
            {
                return false;
            }
            return true;
        }

        private static void Print()
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    var current = chessboard[i, j];
                    Console.Write(current == "Q" ? "*" : "-");
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            PlaceQueen(0);
        }
    }
}