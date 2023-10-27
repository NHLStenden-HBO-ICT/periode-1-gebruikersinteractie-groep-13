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
using System.Windows.Navigation;
using System.Data.SqlClient;

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            SqlCommand sqlcmd;
            string sql = "SELECT TOP 10 Naam, score FROM PlayerInfo WHERE score Is NOT NULL ORDER BY score DESC";
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
                        datalist.Items.Add(name + "   " + scoreText);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window Main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            Main.Show();

        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            Window Menu = new Menu("null", "null", "null", "null");
            this.Visibility = Visibility.Hidden;
            Menu.Show();

        }
    }

}
