using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }

        public bool HasMoved { get; set; } = false; //has moved jest używane do np. Roszad gdzi ekról jeszcze sie nie ruszyŁ

        public abstract Piece Copy();
    }
}
