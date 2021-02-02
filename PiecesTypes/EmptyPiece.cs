using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess
{
    class EmptyPiece : IPiece
    {
        private Point position;

        public EmptyPiece(Point pos)
        {
            Position = pos;
        }
        public PieceType PieceType => PieceType.None;

        public Color PieceColor => Color.None;

        public string ImageString => "";

        public int PieceTypeNumber
        {
            get => 0;
        }

        public int PieceTypeId
        {
            get => 4;
        }

        public Point Position { get => position; set => position = value; }//Check

        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            return new List<Point>();
        }

        public int getPositionalValue()
        {
            return 0;
        }
    }
}
