using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    class Knight
    {
        private int row;
        private int column;
        private ChessBoard chessBoard;

        public Knight(int row, int column, ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
            MoveTO(row, column, 1);
        }

        public Knight(ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
            MoveTO(4, 4, 1);
        }

        public int MoveDumb()
        {
            //Random rand = new Random();
            //get array of valid moves from current position
            int[][] moves = getMoves();
            int counter = 1;
            while (moves.Length > 0)
            {
                int next = Utils.NextRandom(moves.Length);
                MoveTO(moves[next][0], moves[next][1], ++counter); //move to next rand
                moves = getMoves();
            }
            return counter;
        }

        public int MoveSmart()
        {
            //TODO complete this
            int counter = 1;
            int[][] moves = getMoves();
            while (moves.Length > 0)
            {
                int[] reach = new int[moves.GetLength(0)];

                //creating array of move's reach
                for (int i = 0; i < reach.Length; i++)
                {
                    reach[i] = chessBoard.Board[moves[i][0], moves[i][1]].Reach;
                }

                //finding all positions with lowest reach
                for (int i = 0; i < reach.Length; i++)
                {
                    reach[i] = chessBoard.Board[moves[i][0], moves[i][1]].Reach;
                }
                int minReach = reach.Min();
                //int minIndex = Array.IndexOf(reach, reach.Min()); //first minIndex
                List<int> minIndexes = new List<int>();
                for (int i = 0; i < reach.Length; i++)
                {
                    if (reach[i] == minReach)
                    {
                        minIndexes.Add(i);
                    }
                }
                int minIndex = Utils.NextRandom(minIndexes.Count);
                MoveTO(moves[minIndexes[minIndex]][0], moves[minIndexes[minIndex]][1], ++counter); //move to next minIndex
                moves = getMoves();
            }
            return counter;

        }

        private void MoveTO(int row, int column, int counter)
        {
            this.row = row;
            this.column = column;
            //Console.WriteLine("{0}-> {1},{2}", counter, row, column);
            chessBoard.Board[row, column].Order = counter;
            chessBoard.Board[row, column].IsCovered = true;
        }
        //return all possible moves
        private int[][] getMoves()
        {
            int[][] moves = new int[8][];

            moves[0] = new int[] { row + 1, column - 2 };
            moves[1] = new int[] { row + 2, column - 1 };
            moves[2] = new int[] { row + 2, column + 1 };
            moves[3] = new int[] { row + 1, column + 2 };
            moves[4] = new int[] { row - 1, column + 2 };
            moves[5] = new int[] { row - 2, column + 1 };
            moves[6] = new int[] { row - 2, column - 1 };
            moves[7] = new int[] { row - 1, column - 2 };

            // filtering valid moves, null for invalid moves 

            for (int i = 0; i < moves.Length; i++)
            {
                for (int j = 0; j < moves[i].Length; j++)
                {
                    // if out of board , then move is null
                    if (moves[i][j] >= chessBoard.Size || moves[i][j] < 0)
                    {
                        moves[i] = null;
                        break;
                    }
                }

                //if move was already covered, then move null
                if (moves[i] != null && chessBoard.Board[moves[i][0], moves[i][1]].IsCovered)
                {
                    moves[i] = null;
                }
            }

            //removing null values from array.
            return moves.Where(c => c != null).ToArray();
        }

    }

}
