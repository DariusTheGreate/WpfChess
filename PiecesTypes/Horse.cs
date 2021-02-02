using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess
{
    class Horse : IPiece
    {
        private Color pieceColor;

        private Point position;

        public Horse(Point pos)
        {
            position = pos;
        }

        public Horse(Point pos, Color col)
        {
            position = pos;
            pieceColor = col;
        }

        public PieceType PieceType
        {
            get => PieceType.Horse;
        }

        public Color PieceColor
        {
            get => pieceColor;
            set => pieceColor = value;
        }

        public string ImageString { get { return "♘"; } }
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
            var possibleMoves = new List<Point>();

            if (Position.X - 1 > -1 && Position.Y - 2 > -1)
            {
                Point moveUpLeft = new Point(Position.X - 1, Position.Y - 2);
                possibleMoves.Add(new Point((int)moveUpLeft.X, (int)moveUpLeft.Y));
            }

            if (Position.X + 1 < 8 && Position.Y - 2 > -1)
            {
                Point moveUpRight = new Point(Position.X + 1, Position.Y - 2);
                possibleMoves.Add(new Point((int)moveUpRight.X, (int)moveUpRight.Y));
            }

            if (Position.X - 2 > -1 && Position.Y - 1 > -1)
            {
                Point moveLeftUp = new Point(Position.X - 2, Position.Y - 1);
                possibleMoves.Add(new Point((int)moveLeftUp.X, (int)moveLeftUp.Y));
            }

            if (Position.X - 2 > -1 && Position.Y + 1 < 8)
            {
                Point moveLeftDown = new Point(Position.X - 2, Position.Y + 1);
                possibleMoves.Add(new Point((int)moveLeftDown.X, (int)moveLeftDown.Y));
            }

            if (Position.X + 2 < 8 && Position.Y - 1 > -1)
            {
                Point moveRightUp = new Point(Position.X + 2, Position.Y - 1);
                possibleMoves.Add(new Point((int)moveRightUp.X, (int)moveRightUp.Y));
            }

            if (Position.X + 2 < 8 && Position.Y + 1 < 8)
            {
                Point moveRightDown = new Point(Position.X + 2, Position.Y + 1);
                possibleMoves.Add(new Point((int)moveRightDown.X, (int)moveRightDown.Y));
            }

            if (Position.X - 1 > 0 && Position.Y + 2 < 8)
            {
                Point moveDownLeft = new Point(Position.X - 1, Position.Y + 2);
                possibleMoves.Add(new Point((int)moveDownLeft.X, (int)moveDownLeft.Y));
            }

            if (Position.X + 1 < 8 && Position.Y + 2 < 8)
            {
                Point moveDownRight = new Point(Position.X + 1, Position.Y + 2);
                possibleMoves.Add(new Point((int)moveDownRight.X, (int)moveDownRight.Y));
            }

            return possibleMoves;
        }

        public int getPositionalValue()
        {
            return 0;
        }
    }
}
