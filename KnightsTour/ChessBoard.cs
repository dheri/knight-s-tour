using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    class ChessBoard
    {
        private int size = 8;
        private ChessSquare[,] board;

        public ChessBoard()
        {
            board = new ChessSquare[size, size];
            Init();
        }

        public ChessBoard(int size)
        {
            this.size = size;
            board = new ChessSquare[size, size];
            Init();
        }
        public int Size
        {
            get { return size; }
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

    }
}
