using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class GameState
    {
        public Board Board { get; } //konfiguracja szachownicy
        public Player CurrentPlayer { get; private set; }

        public Result Result { get; private set; } //czyja tura jest (na początku gra jeszcze jest więc rezultat wynosi null)
        public GameState (Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }

        public IEnumerable<Move> LegalMovesforPiece(Position pos) //sprawdza jakie ruchy są legalne
        {
            if(Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLEgal(Board));
        }

        public void MakeMove(Move move) //Robienie ruchu
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
            CheckForGameOver();
        }

        public IEnumerable<Move> AllLegalMovesFir(Player player) //sprawdzanie wszystkich legalnych ruchów
        {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return moveCandidates.Where(move => move.IsLEgal(Board));
        }

        private void CheckForGameOver() //sprawdzanie kiedy koniec gry i czemu
        {
            if (!AllLegalMovesFir(CurrentPlayer).Any())
            {
                if (Board.IsInCheck(CurrentPlayer))
                {
                    Result = Result.Win(CurrentPlayer.Opponent());
                } else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }

        public bool IsGameOver() //ustawianie koniec
        {
            return Result != null;
        }
    }
}
