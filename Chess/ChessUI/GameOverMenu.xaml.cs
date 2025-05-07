using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessLogic;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected; //edzie pokazywać stan wygrany (albo też i remis)
        public GameOverMenu(GameState gamestate) //pobiera tekst końca gry
        {
            InitializeComponent();

            Result result = gamestate.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gamestate.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner) //Tekst kto wygraŁ
        {
            return winner switch
            {
                Player.White => "BIALI WYGRYWAJĄ!",
                Player.Black => "CZARNI WYGRYWAJĄ!",
                _ => "REMIS!"
            };
        }

        private static string PlayerString(Player player) //mówi nazwe gracza
        {
            return player switch
            {
                Player.White => "BIALI",
                Player.Black => "CZARNI",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason, Player currentplayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"PAT - {PlayerString(currentplayer)} NIE MAJĄ RUCHU",
                EndReason.Chekmate => $"MAT - {PlayerString(currentplayer)} PRZEGRYWAJĄ",
                EndReason.FiftyMoveRule => "PAT - ZASADA 50 RUCHÓW",
                EndReason.InsufficientMaterial => "PAT - BRAK MATERIAŁU",
                EndReason.ThreeFoldRepetition => "PAT - RUCHY POWTÓRZYŁY SIĘ 3 RAZY",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected.Invoke(Option.Exit);
        }
    }
}
