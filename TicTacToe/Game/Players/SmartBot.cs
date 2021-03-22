using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game.Field;
using TicTacToe.Game;

namespace TicTacToe.Game.Players
{
    class SmartBot : IPlayer
    {
        private Player player;
        private GameField field;

        private const int WINING_FIELD_SCORE = +10;
        private const int DRAW_FIELD_SCORE = 0;
        private const int LOSING_FIELD_SCORE = -10;

        public SmartBot(Player player, GameField field)
        {
            this.player = player;
            this.field = field;
        }

        public Move getMove()
        {
            return findBestMove(field);
        }

        private int evaluateGameField(GameField field)
        {
            if (field.whoWin() == player)
            {
                return WINING_FIELD_SCORE;
            }
            else if (field.whoWin() == Player.NULL)
            {
                return DRAW_FIELD_SCORE;
            }
            else
            {
                return LOSING_FIELD_SCORE;
            }
        }

        private int minMax(GameField field, int depth, bool isMax)
        {
            int score = evaluateGameField(field);

            if (score == WINING_FIELD_SCORE)
            {
                return score;
            }
            else if (score == LOSING_FIELD_SCORE)
            {
                return score;
            }
            else if (!field.isMovesLeft())
            {
                return 0;
            }

            if (isMax)
            {
                int best = Int32.MinValue;
                
                for (int i = 0; i < field.size; i++)
                {
                    for (int j = 0; j < field.size; j++)
                    {
                        if (field.getStatus(i,j) == Player.NULL)
                        {
                            GameField fieldCopy = field.colne();

                            fieldCopy.makeMove(new Move(player, new CellCoordinats(i,j)));

                            best = Math.Max(best, minMax(fieldCopy, depth + 1, !isMax));
                        }
                    }
                }
                return best;
            }
            else
            {

                int best = Int32.MaxValue;
                
                for (int i = 0; i < field.size; i++)
                {
                    for (int j = 0; j < field.size; j++)
                    {
                        if (field.getStatus(i,j) == Player.NULL)
                        {
                            GameField fieldCopy = field.colne();

                            fieldCopy.makeMove(new Move(Player.PLAYER, new CellCoordinats(i,j)));

                            best = Math.Min(best, minMax(fieldCopy, depth + 1, !isMax));
                        }
                    }
                }
                return best;
            }
        }

        private Move findBestMove(GameField field)
        {
            int bestVal = Int32.MinValue;
            Move bestMove = new Move(player, new CellCoordinats(0, 0));

            for (int i = 0; i < field.size; i++)
            {
                for (int j = 0; j < field.size; j++)
                {
                    if (field.getStatus(i,j) == Player.NULL)
                    {
                        GameField fieldCopy = field.colne();

                        fieldCopy.makeMove(new Move(player, new CellCoordinats(i,j)));

                        int moveVal = minMax(fieldCopy, 0, false);

                        if (moveVal > bestVal)
                        {
                            bestMove = new Move(player, new CellCoordinats(i, j));
                            bestVal = moveVal;
                        }
                    }
                }
            }

            Console.WriteLine($"best Move {bestMove.coordinats.X}, {bestMove.coordinats.Y}");

            return bestMove;
        }

    }
}
