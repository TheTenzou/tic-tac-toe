using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game.Players.Smart
{
    class MoveStrategy
    {
        private List<Move> listOfMoves;
        public Player whoWins { set; get; }

        public void addMove(Move move)
        {
            listOfMoves.Add(move);
        }

        public MoveStrategy()
        {
            this.whoWins = Player.NULL;
        }

        public List<Move> getMoves()
        {
            return listOfMoves;
        }

        public MoveStrategy clone()
        {
            MoveStrategy newMoveStrategy = new MoveStrategy();
            newMoveStrategy.listOfMoves = new List<Move>(this.listOfMoves);
            newMoveStrategy.whoWins = this.whoWins;
            return newMoveStrategy;
        }

        public bool isBetter(MoveStrategy moveSrategy)
        {
            if (this.whoWins > moveSrategy.whoWins)
            {
                return true;
            } 
            else
            {
                return this.listOfMoves.Count < moveSrategy.listOfMoves.Count;
            }
        }
    }
}
