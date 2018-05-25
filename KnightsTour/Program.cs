using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Element;

namespace KnightsTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start\n");

            ChessBoard chessBoard = new ChessBoard();
            Knight knight = new Knight(1, 2, chessBoard);
            knight.MoveDumb();

            Console.WriteLine("\n");

            for (int i = 0; i < chessBoard.Board.GetLength(0); i++)
            {
                for (int j = 0; j < chessBoard.Board.GetLength(1); j++)
                {
                    Console.Write("{0:D2} " , chessBoard.Board[i,j].Order );
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\nProgram complete");
            Console.ReadKey();
        }

    }
}
