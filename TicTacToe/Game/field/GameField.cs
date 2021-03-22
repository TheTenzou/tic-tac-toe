using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;
using TicTacToe;

namespace TicTacToe.Game.Field
{
    class GameField
    {
        public int size { get; }
        private Player[,] grid;

        public void makeMove(Move move)
        {
            grid[move.coordinats.X, move.coordinats.Y] = move.player;
        }

        public Player getStatus(int i, int j)
        {
            return grid[i, j];
        }

        public GameField(int size)
        {
            this.size = size;
            grid = new Player[size, size];
        }

        public GameField colne()
        {
            GameField newField = new GameField(size);
            newField.grid = (Player[,])grid.Clone();
            return newField;
        }

        public bool isMovesLeft()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i,j] == Player.NULL)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Player whoWin()
        {
            Player result = Player.NULL;
            for (int i = 0; i < size; i++)
            {
                result = checkRow(i);
                if (result != Player.NULL)
                    return result;

                result = checkColumn(i);
                if (result != Player.NULL)
                    return result;
            }

            result = checkPrimaryDiagonal();
            if (result != Player.NULL)
                return result;

            result = checkSecondaryDiagonal();
            if (result != Player.NULL)
                return result;

            return Player.NULL;
        }

        private Player checkRow(int row)
        {
            Player result = grid[row, 0];

            for (int i = 1; i < size; i++)
            {
                if (grid[row, i] != result)
                {
                    return Player.NULL;
                }
            }
            return result;
        }

        private Player checkColumn(int column)
        {
            Player result = grid[0, column];

            for (int i = 1; i < size; i++)
            {
                if (grid[i, column] != result)
                {
                    return Player.NULL;
                }
            }
            return result;
        }

        private Player checkPrimaryDiagonal()
        {
            Player result = grid[0, 0];

            for (int i = 1; i < size; i++)
            {
                if (grid[i, i] != result)
                {
                    return Player.NULL;
                }
            }
            return result;
        }

        private Player checkSecondaryDiagonal()
        {
            Player result = grid[0, size-1];

            for (int i = 1; i < size; i++)
            {
                if (grid[i, size-i-1] != result)
                {
                    return Player.NULL;
                }
            }
            return result;
        }
    }
}
