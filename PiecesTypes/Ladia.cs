using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess.PiecesTypes
{
    class Ladia : IPiece
    {
        private Color pieceColor;

        private Point position;

        public Ladia(Point pos)
        {
            position = pos;
        }
        public Ladia(Point pos, Color col)
        {
            position = pos;
            pieceColor = col;
        }

        public PieceType PieceType
        {
            get => PieceType.Ladia;
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

        public string ImageString { get { return "♜"; } }
        public Point Position { get => position; set => position = value; }
        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            var res = new List<Point>();

            var possibleMoves = new List<Point>();
            

            for (int i = 1; i < 8; i++)
            {
                if (Position.Y - i > -1)
                {
                    Point moveUp = new Point(Position.X, Position.Y - i);
                    possibleMoves.Add(new Point((int)moveUp.X, (int)moveUp.Y));

                    if (board[Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y - i)].PieceType != PieceType.None)
                        break;
                }
            }


            for (int i = 1; i < 8; i++)
            {
                if (Position.X - i > -1)
                {
                    Point moveLeft = new Point(Position.X - i, Position.Y);
                    possibleMoves.Add(new Point((int)moveLeft.X, (int)moveLeft.Y));
                    if (board[(int)moveLeft.X, (int)moveLeft.Y].PieceType != PieceType.None)
                        break;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (Position.X + i < 8)
                {
                    Point moveRight = new Point(Position.X + i, Position.Y);
                    possibleMoves.Add(new Point((int)moveRight.X, (int)moveRight.Y));
                    if (board[(int)moveRight.X, (int)moveRight.Y].PieceType != PieceType.None)
                        break;
                }
            }


            for (int i = 1; i < 8; i++)
            {
                if (Position.Y + i < 8)
                {
                    Point moveDown = new Point(Position.X, Position.Y + i);
                    possibleMoves.Add(new Point((int)moveDown.X, (int)moveDown.Y));
                    if (board[(int)moveDown.X, (int)moveDown.Y].PieceType != PieceType.None)
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
