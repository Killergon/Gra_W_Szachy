using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPos { get; } //skąd idzie
        public abstract Position ToPos { get; } //dokąd idzie

        public abstract void Execute(Board board);
    }
}
