using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Field;

namespace TicTacToe.Game.Players
{
    class Bot : IPlayer
    {
        private int size;
        private Player player;
        private GameField field;

        private Random rand = new Random();

        public Bot(Player player, GameField field)
        {
            this.size = field.size;
            this.player = player;
            this.field = field;
        }

        public Move getMove()
        {
            int x = rand.Next() % size;
            int y = rand.Next() % size;
            while(field.getStatus(x,y) != Player.NULL && field.whoWin() == Player.NULL)
            {
                x = rand.Next() % size;
                y = rand.Next() % size;
            }

            return new Move(player, new CellCoordinats(x, y));
        }

    }
}
