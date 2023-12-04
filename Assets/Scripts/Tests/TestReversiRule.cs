using System;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestReversiRule
    {
        [Test]
        public void TestInitialGame()
        {
            var reversi = new Reversi();
            Assert.AreEqual(1, reversi.GetCell(3, 3));
            Assert.AreEqual(1, reversi.GetCell(4, 4));
            Assert.AreEqual(2, reversi.GetCell(3, 4));
            Assert.AreEqual(2, reversi.GetCell(4, 3));
        }
    }

    public class Reversi
    {
        private readonly int[,] _board = new int[8, 8];

        public Reversi()
        {
            // 0: empty, 1: black, 2: white
            _board[3, 3] = 1;
            _board[4, 4] = 1;
            _board[3, 4] = 2;
            _board[4, 3] = 2;
        }

        public double GetCell(int row, int col)
        {
            return _board[row, col];
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