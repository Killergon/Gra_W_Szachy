using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class NormalMove : Move
    {
        //Nadpisywanie danych z Move.cs
        public override MoveType Type => MoveType.Normal;
        public override Position FromPos { get; }

        public override Position ToPos { get; }

        public NormalMove(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
        }

        public override void Execute(Board board)
        {
            Piece piece = board[FromPos]; //bierze miejsce poprzedniego pionka
            board[ToPos] = piece; //dodaje pionek na nowe miejsce
            board[FromPos] = null; //usuwa poprzedni pionek
            piece.HasMoved = true; //i daje kolej drugiemu graczowi
        }
    }
}
