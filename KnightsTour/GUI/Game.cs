using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using Element;

namespace GUI
{
    class Game
    {
        public Element.ChessBoard chessBoard;
        private Knight knight;
        private string algorithmType;
        private int numOfMoves;
        public int TotalMoves { get; set; }

        public Game(string algorithmType, int initialX, int initialY)
        {
            Init(initialX, initialY);
            this.algorithmType = algorithmType;
        }
        public void Init(int initialX, int initialY)
        {
            chessBoard = new Element.ChessBoard();
            if (initialX == -1 && initialY == -1)
            {
                knight = new Knight(RandomPosition(), RandomPosition(), chessBoard);
            }
            else
            {
                knight = new Knight(initialX, initialY, chessBoard);
            }
            //knight = new Knight();
        }

        public int play()
        {
            int moves = 0;
            if (algorithmType.Equals("dumb"))
            {
                moves = knight.MoveDumb();
            }
            else
            {
                moves = knight.MoveSmart();
            }
            numOfMoves = moves;
            return moves;
        }

        private int RandomPosition()
        {
            return Utils.NextRandom(8);
        }
    }

}
