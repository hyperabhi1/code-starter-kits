using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game game;

        public GameFixture()
        {
            game = new Game();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void rollSpare()
        {
            game.Roll(6);
            game.Roll(4);
        }

        /// <summary>
        /// Test All Zero Pin
        /// </summary>
        [TestMethod]
        public void TestAll0Pin()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, game.GetScore());
        }

        /// <summary>
        /// Test All Ones
        /// </summary>
        [TestMethod]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        /// <summary>
        /// Test One Spare
        /// </summary>
        [TestMethod]
        public void Test1Spare()
        {
            rollSpare();
            game.Roll(4);
            rollMany(17, 0);
            Assert.AreEqual(18, game.GetScore());
        }
        /// <summary>
        /// Test One Strike
        /// </summary>
        [TestMethod]
        public void Test1Strike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            rollMany(17, 0);
            Assert.AreEqual(28, game.GetScore());
        }

        /// <summary>
        /// Test Perfect Game
        /// </summary>
        [TestMethod]
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, game.GetScore());
        }

        /// <summary>
        /// Test Random Game with No Extra Roll
        /// </summary>
        [TestMethod]
        public void TestNoExtraRoll()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, game.GetScore());
        }

        /// <summary>
        /// Test Random Game With Spare Then Strike At End
        /// </summary>
        [TestMethod]
        public void TestSpareThenStrikeAtEnd()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, game.GetScore());
        }

        /// <summary>
        /// Test Random Game With Three Strikes At End
        /// </summary>
        [TestMethod]
        public void Test3StrikesAtEnd()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.AreEqual(163, game.GetScore());
        }
    }
}
