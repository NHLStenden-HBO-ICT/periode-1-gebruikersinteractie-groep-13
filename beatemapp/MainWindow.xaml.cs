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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getData();
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window Invul = new Invul();
            this.Visibility = Visibility.Hidden;
            Invul.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            Window Leader = new Leaderboard();
            this.Visibility = Visibility.Hidden;
            Leader.Show();
        }

        public void getData()
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            SqlCommand sqlcmd;
            string sql = "SELECT TOP 5 Naam, score FROM PlayerInfo WHERE score Is NOT NULL ORDER BY score DESC";
            try
            {
                conn.Open();
                sqlcmd = new SqlCommand(sql, conn);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                        string name = reader.GetString(0);
                        int score = reader.GetInt32(1);
                        string scoreText = Convert.ToString(score);
                        LeaderScores.Items.Add(name + "   " + scoreText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }

        public void OnClick3(object sender, RoutedEventArgs e)
        {
            Window Help = new Help();
            this.Visibility = Visibility.Hidden;
            Help.Show();
        }

    }
}
