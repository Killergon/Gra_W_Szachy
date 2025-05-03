using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight; //nadpisanie typu pionka
        public override Player Color { get; } //kolor pionka

        public Knight(Player color)  //ustawianie kolor pionka pod kątem gracza
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
