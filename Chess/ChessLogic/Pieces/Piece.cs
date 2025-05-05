namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }

        public bool HasMoved { get; set; } = false; //has moved jest używane do np. Roszad gdzi ekról jeszcze sie nie ruszyŁ

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board); //pozwoli sprawdzić gdzie jest pionek, ruch pionka, i czy może w wymagane pole wejść

        protected IEnumerable<Position> MovePositionInDir(Position from, Board board, Direction dir)
        {
            for (Position pos = from + dir; Board.IsInside(pos); pos += dir) //sprawdza czy jakiś pionek jest w pozycji o jeden o kierunek od pozycji pionka (dziaŁa dla gońca, wieży i hetmana)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (piece.Color != Color)
                {
                    yield return pos;
                }

                yield break;
            }
        }

        protected IEnumerable<Position> MovePositionInDirs(Position from, Board board, Direction[] dirs) //robi to co u góry
        {
            return dirs.SelectMany(dir => MovePositionInDir(from, board, dir));
        }

        public virtual bool CanCaptureOpponentKing(Position from, Board board) //Sprawdza czy można zdobyć króla (faktycznie nie bierze ale używany jest do szachu)
        {
            return GetMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
