using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChess.PrimitiveTests
{
    class Test
    {
        public void TestEntryPoint()
        {
            testBoard();
            testPlayableMoves();
        }

        private void testBoard()
        {
            ChessBoard board = new ChessBoard();
            board.MakeEmptyBoard();
            for(int i = 0; i < board.Board.GetLength(0); i++)
            {
                for (int j = 0; j < board.Board.GetLength(1); j++)
                {
                    Assert.AreEqual(board.Board[i,j].PieceType, PieceType.None);
                }
            }
        }

        private void testPlayableMoves()
        {
            ChessBoard board = new ChessBoard();
            board.MakeEmptyBoard();
            for(int i = 2; i < 5; i++)
            {
                for(int j = 2; j < 5; j++)
                {
                    var king = new King(new System.Windows.Point(i, j), Color.Black);
                    Assert.AreEqual(king.GetPlayableMoves(board.Board).Count, 9);
                }
            }

            board.MakeEmptyBoard();
            var queen = new Queen(new System.Windows.Point(4, 4), Color.Black);
            Assert.AreEqual(queen.GetPlayableMoves(board.Board).Count, 26);
            
            //...
            //copypast 
            //...
        }

        private void testBot()
        {
            throw new NotImplementedException("сперва сделай bot-а");
        }

    }
}
