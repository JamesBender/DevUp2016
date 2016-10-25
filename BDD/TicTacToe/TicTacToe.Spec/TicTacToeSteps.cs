using System;
using System.Security.Cryptography;
using System.Security.Policy;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TicTacToe.Core;

namespace TicTacToe.Spec
{
    [Binding]
    public class TicTacToeSteps
    {
        private string[,] _board;
        private GameEngine _gameEngine;
        private string _result;

        [Given(@"I have a tic tac toe board")]
        public void GivenIHaveATicTacToeBoard()
        {
            _board = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
        }
        
        [Given(@"the board is empty")]
        public void GivenTheBoardIsEmpty()
        {
            _board = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
        }
        
        [When(@"I determine the winner")]
        public void WhenIDetermineTheWinner()
        {
            _gameEngine = new GameEngine();

            _result = _gameEngine.GetWinner(_board);
        }
        
        [Then(@"the result no winner yet")]
        public void ThenTheResultNoWinnerYet()
        {
            Assert.AreEqual(" ", _result);
        }

        [Given(@"the top row is all ""(.*)""")]
        public void GivenTheTopRowIsAll(string p0)
        {
            _board[0, 0] = p0;
            _board[0, 1] = p0;
            _board[0, 2] = p0;
        }

        [Then(@"the result is ""(.*)"" wins")]
        public void ThenTheResultIsWins(string p0)
        {
            Assert.AreEqual(p0, _result);
        }

        [Given(@"it looks like this")]
        public void GivenItLooksLikeThis(Table table)
        {
            _board[0, 0] = table.Rows[0]["Col1"]; //Can access by col name (preffered)
            _board[0, 1] = table.Rows[0][1]; //Can also be accessed by col index (0 based)
            _board[0, 2] = table.Rows[0]["Col3"];
        }


    }
}
