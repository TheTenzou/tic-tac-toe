using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game.Players.Smart
{
    class MoveStategy
    {
        private List<Move> listOfMoves;
        public Player whoWins { set; get; }

        public void addMove(Move move)
        {
            listOfMoves.Add(move);
        }

        public List<Move> getMoves()
        {
            return listOfMoves;
        }
    }
}
