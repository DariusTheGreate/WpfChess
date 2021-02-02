using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess.PiecesTypes
{
    class Ferz : IPiece
    {
        private Color pieceColor;

        private Point position;

        

        public Ferz(Point pos)
        {
            position = pos;
        }
        public Ferz(Point pos, Color col)
        {
            position = pos;
            pieceColor = col;
        }

        public PieceType PieceType
        {
            get => PieceType.Ferz;
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

        public string ImageString { get { return "♗"; } }
        public Point Position { get => position; set => position = value; }
        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            var res = new List<Point>();
            var possibleMoves = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                if (Position.X - i > -1 && Position.Y - i > -1)
                {
                    Point moveUpLeft = new Point(Position.X - i, Position.Y - i);
                    possibleMoves.Add(new Point((int)moveUpLeft.X, (int)moveUpLeft.Y));

                    if (board[Convert.ToInt32(Position.X - i), Convert.ToInt32(Position.Y - i)].PieceType != PieceType.None)
                        break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (Position.X + i < 8 && Position.Y - i > -1)
                {
                    Point moveUpRight = new Point(Position.X + i, Position.Y - i);
                    possibleMoves.Add(new Point((int)moveUpRight.X, (int)moveUpRight.Y));
                    if (board[(int)moveUpRight.X, (int)moveUpRight.Y].PieceType != PieceType.None)
                        break;
                }
            }


            for (int i = 1; i < 8; i++)
            {
                if (Position.X - i > -1 && Position.Y + i < 8)
                {
                    Point moveDownLeft = new Point(Position.X - i, Position.Y + i);
                    possibleMoves.Add(new Point((int)moveDownLeft.X, (int)moveDownLeft.Y));
                    if (board[(int)moveDownLeft.X, (int)moveDownLeft.Y].PieceType != PieceType.None)
                        break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (Position.X + i < 8 && Position.Y + i < 8)
                {
                    Point moveDownRight = new Point(Position.X + i, Position.Y + i);
                    possibleMoves.Add(new Point((int)moveDownRight.X, (int)moveDownRight.Y));
                    if (board[(int)moveDownRight.X, (int)moveDownRight.Y].PieceType != PieceType.None)
                        break;
                }
            }

            return possibleMoves;
        }

        public int getPositionalValue()
        {
            return 0;
        }
    }
}
