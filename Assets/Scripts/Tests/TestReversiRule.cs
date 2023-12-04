using Core;
using NUnit.Framework;

namespace Tests
{
    public class TestReversiRule
    {
        private Reversi _reversi;

        [SetUp]
        public void Setup()
        {
            _reversi = new Reversi();
        }

        [Test]
        public void TestInitialGame()
        {
            Assert.AreEqual(1, _reversi.GetCell(3, 3));
            Assert.AreEqual(1, _reversi.GetCell(4, 4));
            Assert.AreEqual(2, _reversi.GetCell(3, 4));
            Assert.AreEqual(2, _reversi.GetCell(4, 3));
            _reversi.PrintBoard();
        }

        [Test]
        public void FirstRound()
        {
            _reversi.MakeMove(2, 3, 2);
            Assert.AreEqual(2, _reversi.GetCell(2, 3));
            Assert.AreEqual(2, _reversi.GetCell(3, 3));
            _reversi.PrintBoard();
        }
    }
}