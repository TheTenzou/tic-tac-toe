using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Field;

namespace TicTacToe.Game.Players.Smart
{
    class SmartBot : IPlayer
    {
        private Player player;
        private GameField field;

        public SmartBot(Player player, GameField field)
        {
            this.player = player;
            this.field = field;
        }

        public Move getMove()
        {
            throw new NotImplementedException();
        }

        private generateMove(GameField tempField)
        {
            
        }
    }
}
