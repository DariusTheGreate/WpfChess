using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess
{
    class ChessBoard
    {
        private IPiece[,] board;
        
        public ChessBoard()
        {
            board = new IPiece[8,8];
        }

        public ChessBoard(ChessBoard board)
        {
            this.board = board.Board;
        }

        public ChessBoard(IPiece[,] board)
        {
            this.board = board;
        }

        public IPiece[,] Board
        {
            get => board;
            set => board = value;
        }

        public void MakeEmptyBoard()
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new EmptyPiece(new Point(i,j));
                }
            }
        }
    }
}
