﻿namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn; //nadpisanie typu pionka
        public override Player Color { get; } //kolor pionka

        private readonly Direction foward;
        public Pawn(Player color)  //ustawianie kolor pionka pod kątem gracza
        { 
            Color = color;
            if (color == Player.White) //sprawdza jaki pionek ma kolor bo od tego zależy kierunek
            {
                foward = Direction.North;
            }
            else if (color == Player.Black) 
            { 
                foward = Direction.South;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board) //Sprawdza czy pionek może sie poruszyć
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board) //Sprawdza czy może zbić
        {
            if(!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        private static IEnumerable<Move> PromotionMove(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
            yield return new PawnPromotion(from, to, PieceType.Queen);

            
        }

        private IEnumerable<Move> FowardMoves(Position from, Board board) //Sprawdzanie co do zmiany pozycji
        {
            Position oneMovePosition = from + foward;

            if(CanMoveTo(oneMovePosition, board))
            {
                if(oneMovePosition.Row == 0 || oneMovePosition.Row == 7) //Sprawdzanie czy przeszŁo do końca planszy (awanse)
                {
                    foreach(Move promMove in PromotionMove(from , oneMovePosition))
                    {
                        yield return promMove;
                    }
                } else
                {
                    yield return new NormalMove(from, oneMovePosition);
                }
                
                Position twoMovePosition = oneMovePosition + foward;

                if(!HasMoved && CanMoveTo(twoMovePosition, board))
                {
                    yield return new NormalMove(from, twoMovePosition);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board) //Ruchy po przekątnej
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + foward + dir;

                if(CanCaptureAt(to, board))
                {
                    if (to.Row == 0 || to.Row == 7) //Sprawdzanie czy przeszŁo do końca planszy (awanse)
                    {
                        foreach (Move promMove in PromotionMove(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return FowardMoves(from, board).Concat(DiagonalMoves(from, board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board) //sprawdanie szacha
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
