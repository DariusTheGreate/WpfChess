using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfChess.PiecesTypes
{
    class Person : IPiece
    {
        private Color pieceColor;

        private Point position;

        public Person(Point pos)
        {
            position = pos;
        }

        public Person(Point pos, Color col)
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

        public string ImageString { get { return "p"; } }
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
            int x, y;
            Random r = new Random();
            for (int i = 0; i < 4;i++) 
            {
                x = r.Next(1, 8);
                y = r.Next(1, 8);
                if(board[x,y].PieceColor != pieceColor)
                    possibleMoves.Add(new Point(x, y));
            }
            return possibleMoves;
        }

        public int getPositionalValue()
        {
            return 0;
        }
    }
}
