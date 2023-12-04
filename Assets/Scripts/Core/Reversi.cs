using System;
using UnityEngine;

namespace Core
{
    public class Reversi
    {
        private readonly int[,] _board = new int[8, 8];

        public Reversi()
        {
            // 0: empty, 1: white, 2: black
            _board[3, 3] = 1;
            _board[4, 4] = 1;
            _board[3, 4] = 2;
            _board[4, 3] = 2;
        }

        public double GetCell(int row, int col)
        {
            return _board[row, col];
        }

        private bool IsMoveValid(int row, int col, int color)
        {
            if (_board[row, col] != 0)
            {
                return false;
            }

            foreach (var (dr, dc) in new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
            {
                var r = row + dr;
                var c = col + dc;

                while (ValidInBoard(r, c) && _board[r, c] != 0 && _board[r, c] != color)
                {
                    r += dr;
                    c += dc;
                }

                if (ValidInBoard(r, c) && _board[r, c] == color && (r != row + dr || c != col + dc))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ValidInBoard(int r, int c)
        {
            return r is >= 0 and < 8 && c is >= 0 and < 8;
        }

        public void MakeMove(int row, int col, int color)
        {
            if (IsMoveValid(row, col, color) == false) throw new Exception("Invalid move");

            _board[row, col] = color;

            foreach (var (dr, dc) in new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
            {
                var r = row + dr;
                var c = col + dc;

                while (r is >= 0 and < 8 && c is >= 0 and < 8 && _board[r, c] != 0 && _board[r, c] != color)
                {
                    r += dr;
                    c += dc;
                }

                if (r < 0 || r >= 8 || c < 0 || c >= 8 || _board[r, c] != color ||
                    (r == row + dr && c == col + dc)) continue;
                while (r != row || c != col)
                {
                    _board[r, c] = color;
                    r -= dr;
                    c -= dc;
                }
            }
        }

        public void PrintBoard()
        {
            var line = "    1   2   3   4   5   6   7   8\n";
            line += "  ---------------------------------\n";
            for (var row = 0; row < 8; row++)
            {
                var player = " ";
                for (var col = 0; col < 8; col++) player += _board[row, col] + "   ";

                line += $"{row + 1} |{player}|\n";
            }

            line += "  ----------------------------------";
            Debug.Log(line);
        }
    }
}