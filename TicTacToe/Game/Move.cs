using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    class Move
    {
        public Player player { get; }
        public CellCoordinats coordinats { get; }

        public Move(Player player, CellCoordinats coordinats)
        {
            this.player = player;
            this.coordinats = coordinats;
        }        
    }
}
