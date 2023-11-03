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
            string scorePlayer2 = Convert.ToString(player2Score);
            NamePlayer.Text = PlayerName + ":";
            NamePlayer2.Text = Player2Name + ":";
            PlayerScore.Text = scorePlayer;
            Player2Score.Text = scorePlayer2;
            Player_Email.Text = playerEmail;
            Player2_Email.Text = player2Email;
            insertScore(playerEmail, player2Email, player1Score, player2Score);
        }

        public void insertScore(string emailPlayer, string EmailPlayer2, int scorePlayer, int scorePlayer2)
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            SqlCommand sqlcmd;
            SqlCommand sqlcmd2;
            SqlCommand sqlcmd3;
            string sql = "SELECT score FROM PlayerInfo WHERE Email ='" + emailPlayer + "'";
            string sql2 = "SELECT score FROM PlayerInfo WHERE Email ='" + EmailPlayer2 + "'";
            string sqlUpdate = "UPDATE PlayerInfo SET score='" + scorePlayer + "' Where Email='" + emailPlayer + "'";
            string sqlUpdate2 = "UPDATE PlayerInfo SET score='" + scorePlayer2 + "' Where Email='" + EmailPlayer2 + "'";
            string sqlLeaderboard = "SELECT Email, score FROM PlayerInfo ORDER BY score DESC";
            try
            {
                conn.Open();

                List<int> Score = new List<int>();
                List<string> leaderboard = new List<string>();
                sqlcmd = new SqlCommand(sql, conn);
                sqlcmd2 = new SqlCommand(sql2, conn);
                sqlcmd3 = new SqlCommand(sqlLeaderboard, conn);
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
                    BestScore1.Text = "best score: " + Convert.ToString(scorePlayer);
                }
                else
                {
                    BestScore1.Text = "best score: " + Convert.ToString(Score[0]);
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
                    BestScore2.Text = "best score: " + Convert.ToString(scorePlayer2);
                }
                else
                {
                    BestScore2.Text = "best score: " + Convert.ToString(Score[1]);
                }

                SqlDataReader PlaatsNumber = sqlcmd3.ExecuteReader();
                while (PlaatsNumber.Read())
                {

                    string Emails = PlaatsNumber.GetString(0);
                    int score = PlaatsNumber.GetInt32(1);
                    string scoreText = Convert.ToString(score);

                    leaderboard.Add(Emails);
                    for (int i = 0; i < leaderboard.Count; i++)
                    {
                        string plaatsing = Convert.ToString(1 + i);

                        if (emailPlayer == leaderboard[i])
                        {
                            LeaderPlayer1.Text = "Plaatsing: " + plaatsing;
                        }

                        if (EmailPlayer2 == leaderboard[i])
                        {
                            LeaderPlayer2.Text = "Plaatsing: " + plaatsing;
                        }
                    }
                }
                PlaatsNumber.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Game(NamePlayer.Text, NamePlayer2.Text, Player_Email.Text, Player2_Email.Text, 0, 0, 0, 0, true));
            this.Visibility = Visibility.Hidden;
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            Window Main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            Main.Show();
        }
    }
}
