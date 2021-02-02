using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfChess
{
    class Knight : IPiece
    {
        private Color color;
        private Point position;

        private readonly int[,] whitePawnTable = new int[,]
        {
         {60,  80,  80,  80,  80,  80,  80,  60},
         {50, 50, 50, 50, 50, 50, 50, 50},
         {10, 10, 20, 30, 30, 20, 10, 10},
         {5,  5, 10, 25, 25, 10,  5,  5},
         {0,  0,  0, 20, 20,  0,  0,  0},
         {5, -5,-10,  0,  0,-10, -5,  5},
         {5, 10, 10,-20,-20, 10, 10,  5},
         {0,  0,  0,  0,  0,  0,  0,  0}
        };

        private readonly int[,] blackPawnTable = new int[,]
        {
         {0,  0,  0,  0,  0,  0,  0,  0},
        {5, 10, 10,-20,-20, 10, 10,  5},
        {5, -5,-10,  0,  0,-10, -5,  5},
        {0,  0,  0, 20, 20,  0,  0,  0},
        {5,  5, 10, 25, 25, 10,  5,  5},
        {10, 10, 20, 30, 30, 20, 10, 10},
        {50, 50, 50, 50, 50, 50, 50, 50},
        {60,  80,  80,  80,  80, 80,  80,  60}
        };

        public Knight(Point pos, Color col)
        {
            position = pos;
            color = col;
        }

        public PieceType PieceType => PieceType.King;

        public Color PieceColor 
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public string ImageString => "Ферзь";

        public int PieceTypeNumber
        {
            get => 1000;
        }

        public int PieceTypeId
        {
            get => 2;
        }

        public Point Position { get => position; set => position = value; }

        public List<Point> GetPlayableMoves(IPiece[,] board)
        {
            var res = new List<Point>();
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx*dx + dy*dy != 1)
                        continue;
                    var a = Convert.ToInt32(Position.X) + dx;
                    var b = Convert.ToInt32(Position.Y) + dy;
                    if (a < board.GetLength(0) && a > -1 && b < board.GetLength(1) && b > -1)
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
            return this.PieceColor == Color.White ? whitePawnTable[Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y)] : blackPawnTable[Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y)];
        }
    }
}
