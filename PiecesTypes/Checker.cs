using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfChess
{
    class Checker : IPiece
    {
        private Color pieceColor;

        private Point position;

        public Checker(Point pos)
        {
            position = pos;
        }
        public Checker(Point pos, Color col)
        {
            position = pos;
            pieceColor = col;
        }

        public PieceType PieceType
        {
            get => PieceType.Checker;
        }

        public Color PieceColor
        {
            get => pieceColor;
            set => pieceColor = value;
        }

        public int PieceTypeNumber
        {
            get => 100;
        }

        public int PieceTypeId
        {
            get => 3;
        }

        public string ImageString { get { return "♙"; } }
        public Point Position { get => position; set => position = value; }
        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            var res = new List<Point>();
            
            if(position.Y == 1 && PieceColor == Color.Black)
            {
                var p = new Point(position.X + 1, Position.Y +1);
                if(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y + 1)].PieceType == PieceType.None)
                    res.Add(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y + 1)].Position);
                
                   
                if(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y + 1)].PieceType == PieceType.None && board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y + 2)].PieceType == PieceType.None)
                res.Add(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y + 2)].Position);

            }
            
            if (position.Y == 6 && PieceColor == Color.White)
            {
                if (board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y -1)].PieceType == PieceType.None)
                    res.Add(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y -1)].Position);
                if (board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y - 2)].PieceType == PieceType.None && board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y - 1)].PieceType == PieceType.None)
                    res.Add(board[Convert.ToInt32(position.X), Convert.ToInt32(Position.Y - 2)].Position);
            }

            if (pieceColor == Color.Black)
            {
                var d = Convert.ToInt32(Position.Y) + 1;
                if (d < board.GetLength(1) && d > -1 && board[Convert.ToInt32(position.X), d].PieceColor == Color.None)
                {
                    var pp = board[Convert.ToInt32(position.X), d];
                    res.Add(pp.Position);
                }
            }
            
            else if (pieceColor == Color.White)
            {
                var d = Convert.ToInt32(Position.Y) - 1;
                if (d < board.GetLength(1) && d > -1 && board[Convert.ToInt32(position.X), d].PieceColor == Color.None)
                {
                    var pp = board[Convert.ToInt32(position.X), d];
                    res.Add(pp.Position);
                }
            }

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 || dy == 0 || PieceColor == Color.White && (dy == 1) || PieceColor == Color.Black && (dy == -1))
                        continue;
                    var a = Convert.ToInt32(Position.X) + dx;
                    var b = Convert.ToInt32(Position.Y) + dy;
                    if (a < board.GetLength(0) && a > -1 && b < board.GetLength(1) && b > -1)
                    {
                        var pp = board[a, b];
                        if(pp.PieceType != PieceType.None && pp.PieceColor != PieceColor)
                            res.Add(pp.Position);
                    }
                }
            }
            
            return res;
        }

        public int getPositionalValue()
        {
            return 0;
        }
    }
}
