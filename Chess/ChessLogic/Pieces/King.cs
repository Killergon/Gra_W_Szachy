using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King; //nadpisanie typu pionka
        public override Player Color { get; } //kolor pionka

        public King(Player color)  //ustawianie kolor pionka pod kątem gracza
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
