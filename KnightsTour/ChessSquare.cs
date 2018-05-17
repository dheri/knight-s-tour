using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class ChessSquare
    {
        private int boardSize = 8;
        private string name;
        private int row;
        private int column;
        private int number;
        private int reach;

        public ChessSquare(int row, int column)
        {
            this.row = row;
            this.column = column;

            number = (row * 8 + column) + 1;
            name = "" + (row + 1) + (char)(column + 65);
            SetReach();
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public int Reach
        {
            get
            {
                return reach;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public void SetReach()
        {
            if (row == 0 || row == boardSize - 1)
            {
                if (column == 0 || column == boardSize -1)
                {
                    reach = 2;
                }
                else if (column == 1 || column == boardSize - 2)
                {
                    reach = 3;
                }
                else
                {
                    reach = 4;
                }
            }
            else if (row == 1 || row == boardSize - 2)
            {
                if (column == 0 || column == boardSize - 1)
                {
                    reach = 3;
                }
                else if (column == 1 || column == boardSize - 2)
                {
                    reach = 4;
                }
                else
                {
                    reach = 6;
                }
            }
            else
            {
                if (column == 0 || column == boardSize - 1)
                {
                    reach = 4;
                }
                else if (column == 1 || column == boardSize - 2)
                {
                    reach = 6;
                }
                else
                {
                    reach = 8;
                }
            }
        }
    }



}
