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
        public Player CurrentPlayer { get; private set; } //czyja tura jest

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
            return piece.GetMoves(pos, Board);
        }

        public void MakeMove(Move move) //RObienie ruchu
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
        }
    }
}
