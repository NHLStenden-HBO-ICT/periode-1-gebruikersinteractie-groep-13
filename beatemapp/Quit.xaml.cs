using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Quit.xaml
    /// </summary>
    public partial class Quit : Window
    {
        public Quit(String PlayerName, String Player2Name, string playerEmail, string player2Email, int player1Score, int player2Score)
        {
            InitializeComponent();

            string scorePlayer = Convert.ToString(player1Score);
            string scorePlayer2 = Convert.ToString(player2Score);
            NamePlayer.Text = PlayerName + ":";
            NamePlayer2.Text = Player2Name + ":";
            PlayerScore.Text = scorePlayer;
            Player2Score.Text = scorePlayer2;
            Player_Email.Text = playerEmail;
            Player2_Email.Text = player2Email;

        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window game = new Game(NamePlayer.Text, NamePlayer2.Text, Player_Email.Text, Player2_Email.Text, true);
            this.Visibility = Visibility.Hidden;
            game.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
                stopMessage.Visibility = Visibility.Visible;
                Back.IsEnabled = false;
                stop.IsEnabled = false;
        }

        public void OnClick3(object sender, RoutedEventArgs e)
        {
            int score = Convert.ToInt32(PlayerScore.Text);
            int score2 = Convert.ToInt32(Player2Score.Text);

            Window Main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            insertScore(Player_Email.Text, Player2_Email.Text, score, score2);
            Main.Show();
        }

        public void insertScore(string emailPlayer, string EmailPlayer2, int scorePlayer, int scorePlayer2)
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            
            SqlCommand sqlcmd;
            SqlCommand sqlcmd2;

            string sql = "SELECT score FROM PlayerInfo WHERE Email ='" + emailPlayer + "'";
            string sql2 = "SELECT score FROM PlayerInfo WHERE Email ='" + EmailPlayer2 + "'";
            string sqlUpdate = "UPDATE PlayerInfo SET score='" + scorePlayer + "' Where Email='" + emailPlayer + "'";
            string sqlUpdate2 = "UPDATE PlayerInfo SET score='" + scorePlayer2 + "' Where Email='" + EmailPlayer2 + "'";

            try
            {
                conn.Open();

                List<int> Score = new List<int>();
                List<string> leaderboard = new List<string>();

                sqlcmd = new SqlCommand(sql, conn);
                sqlcmd2 = new SqlCommand(sql2, conn);

                SqlCommand sqlcmdupdate = new SqlCommand(sqlUpdate, conn);
                SqlCommand sqlcmdupdate2 = new SqlCommand(sqlUpdate2, conn);

                SqlDataReader reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    int score = reader.GetInt32(0);
                    string scores = Convert.ToString(score);
                    Score.Add(score);
                }
                reader.Close();
                if (scorePlayer > Score[0])
                {
                    sqlcmdupdate.ExecuteNonQuery();
                    sqlcmdupdate.Dispose();
                }

                SqlDataReader reader2 = sqlcmd2.ExecuteReader();
                while (reader2.Read())
                {
                    int score2 = reader2.GetInt32(0);
                    string scores2 = Convert.ToString(score2);
                    Score.Add(score2);
                }
                reader2.Close();

                if (scorePlayer2 > Score[1])
                {
                    sqlcmdupdate2.ExecuteNonQuery();
                    sqlcmdupdate2.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }

        public void OnClick4(object sender, RoutedEventArgs e)
        {
            stopMessage.Visibility = Visibility.Hidden;
            Back.IsEnabled = true;
            stop.IsEnabled = true;
        }
    }
}
