using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.field
{
    class GameField
    {
        private int size;
        Status[,] grid;

        public Status this[int index1, int index2]
        {
            get { return grid[index1, index2]; }
            set { grid[index1, index2] = value; }
        }

        public GameField(int size)
        {
            this.size = size;
            grid = new Status[size, size];
        }


        public Status whoWin()
        {
            Status result = Status.NULL;
            for (int i = 0; i < size; i++)
            {
                result = checkRow(i);
                if (result != Status.NULL)
                    return result;

                result = checkColumn(i);
                if (result != Status.NULL)
                    return result;
            }

            result = checkPrimaryDiagonal();
            if (result != Status.NULL)
                return result;

            result = checkSecondaryDiagonal();
            if (result != Status.NULL)
                return result;

            return Status.NULL;
        }

        private Status checkRow(int row)
        {
            Status result = grid[row, 0];

            for (int i = 1; i < size; i++)
            {
                if (grid[row, i] != result)
                {
                    return Status.NULL;
                }
            }
            return result;
        }

        private Status checkColumn(int column)
        {
            Status result = grid[0, column];

            for (int i = 1; i < size; i++)
            {
                if (grid[i, column] != result)
                {
                    return Status.NULL;
                }
            }
            return result;
        }

        private Status checkPrimaryDiagonal()
        {
            Status result = grid[0, 0];

            for (int i = 1; i < size; i++)
            {
                if (grid[i, i] != result)
                {
                    return Status.NULL;
                }
            }
            return result;
        }

        private Status checkSecondaryDiagonal()
        {
            Status result = grid[0, size-1];

            for (int i = 1; i < size; i++)
            {
                if (grid[size - i, i] != result)
                {
                    return Status.NULL;
                }
            }
            return result;
        }
    }
}
