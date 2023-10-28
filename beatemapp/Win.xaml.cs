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

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win : Page
    {
        public Win(string PlayerName, string Player2Name, string playerEmail, string player2Email, int player1Score, int player2Score)
        {
            InitializeComponent();

            string scorePlayer = Convert.ToString(player1Score);
            string scorePlayer2 =Convert.ToString(player2Score);
            PlayerScore.Text = PlayerName + scorePlayer;
            Player2Score.Text = Player2Name + scorePlayer2;
            Player_Email.Text = playerEmail;
            Player2_Email.Text = player2Email;
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {

            Window Game = new Game(PlayerScore.Text, Player2Score.Text, Player_Email.Text, Player2_Email.Text, false);
            this.Visibility = Visibility.Hidden;
            Game.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            Page Main = new Test(PlayerScore.Text, 20);
            this.Visibility = Visibility.Hidden;
            this.NavigationService.Navigate(Main);
        }
    }
}
