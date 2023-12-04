using NUnit.Framework;

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
    }
}