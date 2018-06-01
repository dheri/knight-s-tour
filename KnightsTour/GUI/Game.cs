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
        Element.ChessBoard chessBoard;
        Knight knight;
        private int initialX;
        private int initialY;
        private string algorithmType;

        public Game(string algorithmType, int initialX, int initialY)
        {
            Init();
            this.initialX = initialX;
            this.initialY = initialY;
            this.algorithmType = algorithmType;
        }
        public void Init()
        {
            chessBoard = new Element.ChessBoard();
            if (initialX == -1 && initialY == -1)
            {
                knight = new Knight(RandomPosition(), RandomPosition(), chessBoard);
            }
            else
            {
                knight = new Knight(initialY, initialY, chessBoard);
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
            return moves;
        }

        private int RandomPosition()
        {
            Random rand = new Random();
            return rand.Next(8);
        }
    }

}
