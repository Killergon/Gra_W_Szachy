using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Bishop : Piece
    {
        public override PieceType Type => PieceType.Bishop; //nadpisanie typu pionka
        public override Player Color { get; } //kolor pionka

        public Bishop(Player color)  //ustawianie kolor pionka pod kątem gracza
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
