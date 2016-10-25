using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.Core;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    public class GameEngingeTests
    {
        private string[,] _board;
        private GameEngine _gameEngine;

        [SetUp]
        public void SetupTest()
        {
            _board = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            _gameEngine = new GameEngine();
        }

        [Test]
        public void WhenTheBoardIsEmptyThenThereIsNoWinner()
        {
            //arrainge
            var expectedResult = " ";

            //act
            var result = _gameEngine.GetWinner(_board);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTheTopRowIsAllXThenXWins()
        {
            _board[0, 0] = "X";
            _board[0, 1] = "X";
            _board[0, 2] = "X";

            var expectedResult = "X";

            var result = _gameEngine.GetWinner(_board);

            Assert.AreEqual(expectedResult, result);

        }
    }
}
