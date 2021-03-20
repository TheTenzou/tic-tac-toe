using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    class CellCoordinats
    {
        public int X { get; }
        public int Y { get; }

        public CellCoordinats(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
