using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.Game.Players
{
    interface IPlayer
    {
        Move getMove();
    }
}
