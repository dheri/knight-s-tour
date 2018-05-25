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

        //private int row;
        //private int column;
        //private bool isCovered = false;
        //private int order;

        //not used
        //private int number;
        //private int reach;
        //private string name;

        public ChessSquare(int row, int column)
        {
            Row = row;
            Column = column;

            Number = (row * 8 + column) + 1;
            Name = "" + (row + 1) + (char)(column + 65);
            SetReach();
        }
        private int Row { set; get; }
        private int Column { set; get; }
        public bool IsCovered { get; set; }
        public int Order { get; set; }
        public int Number { get; set; }
        public int Reach { get; set; }
        public string Name { get; set; }


        private void SetReach()
        {
            if (Row == 0 || Row == boardSize - 1)
            {
                if (Column == 0 || Column == boardSize - 1)
                {
                    Reach = 2;
                }
                else if (Column == 1 || Column == boardSize - 2)
                {
                    Reach = 3;
                }
                else
                {
                    Reach = 4;
                }
            }
            else if (Row == 1 || Row == boardSize - 2)
            {
                if (Column == 0 || Column == boardSize - 1)
                {
                    Reach = 3;
                }
                else if (Column == 1 || Column == boardSize - 2)
                {
                    Reach = 4;
                }
                else
                {
                    Reach = 6;
                }
            }
            else
            {
                if (Column == 0 || Column == boardSize - 1)
                {
                    Reach = 4;
                }
                else if (Column == 1 || Column == boardSize - 2)
                {
                    Reach = 6;
                }
                else
                {
                    Reach = 8;
                }
            }
        }
    }



}
