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

    }
}
