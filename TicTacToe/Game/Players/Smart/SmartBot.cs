using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Field;
using TicTacToe.Game;

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
            MoveStrategy moveStrategy = generateMove(field.colne(), new MoveStrategy());
            return moveStrategy.getMoves().First<Move>();
        }

        private MoveStrategy generateMove(GameField tempField, MoveStrategy st)
        {
            int size = tempField.size;

            MoveStrategy result = st;
            GameField resField = tempField;

            if (tempField.whoWin() == Player.NULL)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (tempField.getStatus(i, j) == Player.NULL)
                        {
                            GameField newTempField = tempField.colne();

                            CellCoordinats cell = new CellCoordinats(i, j);
                            Move move = new Move(player, cell);

                            MoveStrategy newMoveStrategy = st.clone();

                            newTempField.makeMove(move);
                            newMoveStrategy.addMove(move);

                            MoveStrategy newResult = generateMove(newTempField, newMoveStrategy);

                            if (result != null && newResult.isBetter(result)/* && newResult.whoWins == Player.BOT*/)
                            {
                                result = newResult;
                                resField = newTempField;
                                Console.WriteLine("test");
                            }
                        }
                    }
                }
                                //Console.WriteLine($"res status: {result.whoWins} moves: {result.getMoves().Count}");
                //result.whoWins = resField.whoWin();
                return result;
            }
            else
            {
                st.whoWins = tempField.whoWin();
                return st;
            }
        }
    }
}
