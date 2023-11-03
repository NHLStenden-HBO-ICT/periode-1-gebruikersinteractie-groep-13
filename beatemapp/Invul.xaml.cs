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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Invul.xaml
    /// </summary>
    public partial class Invul : Window
    {
        public Invul()
        {
            InitializeComponent();
        }
        public void OnClick1(object sender, RoutedEventArgs e)
        {
                Window Main = new MainWindow();
                this.Visibility = Visibility.Hidden;
                Main.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            if (Nameplayer.Text != "" && Nameplayer2.Text != "" && EmailPlayer.Text != "" && EmailPlayer2.Text != "")
            {
                bool isValid = validateEmails(EmailPlayer.Text, EmailPlayer2.Text);
                if (isValid != false)
                {
                    Window Game = new Game(Nameplayer.Text, Nameplayer2.Text, EmailPlayer.Text, EmailPlayer2.Text, 0, 0, 50, 50, false);
                    this.Visibility = Visibility.Hidden;
                    InsertData(Nameplayer.Text, EmailPlayer.Text, Nameplayer2.Text, EmailPlayer2.Text);
                    Game.Show();
                } else
                {
                    Error2.Visibility = Visibility.Visible;
                    Error.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Error.Visibility = Visibility.Visible;
                Error2.Visibility= Visibility.Hidden;
            }
        }

        static bool validateEmails(string Email, string Email2)
        {
            string Emailpattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


            Regex regex = new Regex(Emailpattern);
            return regex.IsMatch(Email) && regex.IsMatch(Email2);
        }

        public static void InsertData(string player1Name, string Player1Email, string player2Name, string player2Email)
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            SqlCommand sqlcmd;
            SqlCommand sqlcmd2;
            string sql = "INSERT INTO PlayerInfo(Naam, Email, score) SELECT '" + player1Name + "','" + Player1Email + "', 0 WHERE NOT EXISTS (SELECT * FROM PlayerInfo WHERE Email = '" + Player1Email + "')";
            string sql2 = "INSERT INTO PlayerInfo(Naam, Email, score) SELECT '" + player2Name + "','" + player2Email + "', 0 WHERE NOT EXISTS (SELECT * FROM PlayerInfo WHERE Email = '" + player2Email + "')";
            try
            {
                conn.Open();
                sqlcmd = new SqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();
                sqlcmd2 = new SqlCommand(sql2, conn);
                sqlcmd2.ExecuteNonQuery();
                sqlcmd2.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }
    }
}
