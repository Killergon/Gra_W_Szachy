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

        private static IEnumerable<Position> PotentialToPositions(Position from) //bierze miejsca gdzie koń może sie ruszyć
        {
            foreach (Direction vDir in new Direction[] { Direction.North, Direction.South })
            {
                foreach (Direction hDir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Board board) //rusza do miejsc które może
        {
            return PotentialToPositions(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board) //pokazuje miejsca do których może sie ruszyć
        {
            return MovePositions(from, board).Select(to => new NormalMove(from, to));
        }
    } 
}
