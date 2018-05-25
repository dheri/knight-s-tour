using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    class ChessSquare
    {
        private int boardSize = 8;

        private int row;
        private int column;
        private bool isCovered = false;
        private int order;

        //not used
        private int number;
        private int reach;
        private string name;

        public ChessSquare(int row, int column)
        {
            this.row = row;
            this.column = column;

            number = (row * 8 + column) + 1;
            name = "" + (row + 1) + (char)(column + 65);
            SetReach();
        }

        public bool IsCovered { get => isCovered; set => isCovered = value; }
        public int Order { get => order; set => order = value; }
        public int Number { get => number; }
        public int Reach { get => reach; }
        public string Name { get => name; }


        private void SetReach()
        {
            if (row == 0 || row == boardSize - 1)
            {
                if (column == 0 || column == boardSize - 1)
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
