using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
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

        private void Init()
        {
            byte counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++, counter++)
                {
                    board[i, j] = new ChessSquare(i, j);
                    //reach

                    Console.Write(" {1} ", board[i, j].Name, board[i, j].Reach);
                }


                Console.WriteLine();
            }
        }

    }
}
