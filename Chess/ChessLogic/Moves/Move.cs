﻿namespace ChessLogic
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPos { get; } //skąd idzie
        public abstract Position ToPos { get; } //dokąd idzie

        public abstract void Execute(Board board);

        public virtual bool IsLEgal(Board board)
        {
            Player player = board[FromPos].Color;
            Board boardcopy = board.Copy();
            Execute(boardcopy);
            return !boardcopy.IsInCheck(player);
        }
    }
}
