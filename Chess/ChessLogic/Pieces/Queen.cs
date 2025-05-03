using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen; //nadpisanie typu pionka
        public override Player Color { get; } //kolor pionka

        public Queen(Player color)  //ustawianie kolor pionka pod kątem gracza
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
