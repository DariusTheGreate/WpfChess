using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfChess
{
    class King : IPiece
    {
        private Color pieceColor;

        private Point position;

        public King(Point pos)
        {
            position = pos;
        }
        public King(Point pos, Color col)
        {
            position = pos;
            pieceColor = col;
        }

        public PieceType PieceType
        {
            get => PieceType.King;
        }

        public Color PieceColor
        {
            get => pieceColor;
            set => pieceColor = value;
        }
        public string ImageString { get => "♚"; }
        public Point Position { get => position; set => position = value; }

        public int PieceTypeNumber
        {
            get => 32000;
        }

        public int PieceTypeId
        {
            get => 1;
        }

        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            var res = new List<Point>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    var a = Convert.ToInt32(Position.X) + dx;
                    var b = Convert.ToInt32(Position.Y) + dy;
                    if (a < board.GetLength(0) && a > 0 && b < board.GetLength(1) && b > -1)
                    {
                        var pp = board[a, b];
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
