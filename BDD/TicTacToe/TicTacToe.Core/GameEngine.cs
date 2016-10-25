using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class GameEngine
    {
        public string GetWinner(string[,] board)
        {
            return board[0, 0];
        }
    }
}
