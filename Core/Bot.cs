using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace WpfChess
{
    class Bot
    {
        private HashSet<IPiece> blackPieces;
        private HashSet<IPiece> whitePieces;
        private IEnumerable<IPiece> blackPiecesIenumerable;
        private IEnumerable<IPiece> whitePiecesIenumerable;
        private IPiece[,] board;
        private IPiece[,] boardClone;
        private Color currentColor;
        private Color enemyColor;

        private double blackPriority;
        private double whitePriority;

        public Bot(IEnumerable<IPiece> blackPieces, IEnumerable<IPiece> whitePieces, IPiece[,] board, Color currentColor)
        {
            blackPiecesIenumerable = blackPieces;
            whitePiecesIenumerable = whitePieces;
            this.board = board;
            boardClone = CloneBoard(board);
            this.currentColor = currentColor;
            enemyColor = currentColor == Color.White ? Color.Black : Color.White;
        }

        public Bot(HashSet<IPiece> blackPieces, HashSet<IPiece> whitePieces, IPiece[,] board, Color currentColor)
        {
            this.blackPieces = blackPieces;
            this.whitePieces = whitePieces;
            this.board = board;
            this.currentColor = currentColor;
        }

        public IPiece[,] Board
        {
            get => board;
        }

        public double WhitePriority
        {
            get => whitePriority;
            set => whitePriority = value;
        }

        public double BlackPriority
        {
            get => blackPriority;
            set => blackPriority = value;
        }

        public IPiece[,] CloneBoard(IPiece[,] board)
        {
            var clone = new IPiece[8,8];//Warning
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    clone[i, j] = board[i, j];//Warning
                }
            }
            return clone;
        }

        public IEnumerable<IPiece> GetPlayablePiece()
        {

            foreach (var piece in blackPieces)
            {
                //Debug.WriteLine("Possible steps " + piece.Position.X + " " + piece.Position.Y);
                var c = 0;
                foreach (var i in piece.GetPlayableMoves(board))
                {
                    if (board[Convert.ToInt32(i.X), Convert.ToInt32(i.Y)].PieceColor == enemyColor)
                        continue;
                    c++;
                }

                if (c > 0)
                    yield return piece;
            }
        }

        public IPiece GetOptimalPlayablePiece()
        {
            var playablePieces = GetPlayablePiece();

            return playablePieces.Last();
        }

        private Point BuildMinMaxTree(IPiece piece, IPiece[,] board, int depth, double alpha, Point res)
        {
            if (depth > 0)
            {
                var newBoard = new IPiece[board.GetLength(0), board.GetLength(1)];
                foreach (var i in piece.GetPlayableMoves(board))
                {
                    newBoard = changeBoard(piece, i);
                    res = i;
                    alpha = CalculateValue(res, board);
                    if (alpha > 1)
                        return res;

                    BuildMinMaxTree(piece, newBoard, depth - 1, alpha, res);
                }
            }
            return res;

        }

        private double CalculateValue(Point piece, IPiece[,] board)
        {
            var res = 0.0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    var a = Convert.ToInt32(piece.X) + dx;
                    var b = Convert.ToInt32(piece.Y) + dy;
                    if (a < board.GetLength(0) && a > -1 && b < board.GetLength(1) && b > -1)
                    {
                        if (board[a, b].PieceColor == Color.White)//!!!
                            res -= 0.5;
                        else
                            res += 0.5;

                    }
                }
            }
            return res;
        }

        private IPiece[,] changeBoard(IPiece piece, Point changePoint)
        {
            board[Convert.ToInt32(piece.Position.X), Convert.ToInt32(piece.Position.Y)] = new EmptyPiece(new Point(piece.Position.X, piece.Position.Y));
            board[Convert.ToInt32(changePoint.X), Convert.ToInt32(changePoint.Y)] = piece;
            return board;
        }

        public Tuple<IPiece, Point> getBestMovePrimitive()
        {
            var optimal = new Point(1,1);
            var optimalStart = blackPieces.First();
            foreach(var i in blackPieces.Where(k => k.GetPlayableMoves(board).Count != 0))
            {
                foreach(var j in i.GetPlayableMoves(board))
                {
                    if (j.X > board.GetLength(0) || j.Y > board.GetLength(1) || j.X < 0 || j.Y < 0)
                        continue;
                    if(board[Convert.ToInt32(j.X), Convert.ToInt32(j.Y)].PieceColor == Color.White)
                    {
                        optimal = j;
                        optimalStart = i;
                    }
                    
                    else if (board[Convert.ToInt32(j.X), Convert.ToInt32(j.Y)].PieceType == PieceType.None)
                    {
                        optimal = j;
                        optimalStart = i;
                            
                    }
                }
                if (optimalStart != blackPieces.First())
                    break;
            }

            return Tuple.Create(optimalStart, optimal);
        }

        private bool CheckMatExists()
        {
            throw new Exception("A");
        }

    }
}