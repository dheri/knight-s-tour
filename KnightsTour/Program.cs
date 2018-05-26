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
            chessBoard.PrintFinalState();

            Console.WriteLine("\n\n\n");

            chessBoard = new ChessBoard();
            knight = new Knight(7, 2, chessBoard);

            knight.MoveSmart();
            Console.WriteLine("\n");
            chessBoard.PrintFinalState();
            Console.WriteLine("\n");


            Console.WriteLine("\nProgram complete");
            Console.ReadKey();
        }

    }
}
