using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
namespace WpfChess
{
    interface IPiece
    {
        PieceType PieceType { get; }
        Color PieceColor { get; }
        string ImageString { get; }
        Point Position { get; set; }
        int PieceTypeNumber { get; }

        List<Point> GetPlayableMoves(IPiece[,] board);
        int getPositionalValue();
    }
}
