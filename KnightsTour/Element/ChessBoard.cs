using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    class ChessBoard
    {
        private ChessSquare[,] board;
        private int size = 8;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public ChessBoard()
        {
            board = new ChessSquare[Size, Size];
            Init();
        }

        public ChessBoard(int size)
        {
            Size = size;
            board = new ChessSquare[size, size];
            Init();
        }


        // Initialize  
        private void Init()
        {
            byte counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++, counter++)
                {
                    board[i, j] = new ChessSquare(i, j);
                    //reach
                }

            }
        }
        public ChessSquare[,] Board
        {
            get { return board; }
        }

        public void PrintFinalState()
        {
            for (int i = 0; i < this.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.Board.GetLength(1); j++)
                {
                    Console.Write("{0:D2} ", this.Board[i, j].Order);
                }
                Console.WriteLine("");
            }
        }

    }
}
