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

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Quit.xaml
    /// </summary>
    public partial class Quit : Window
    {
        public Quit()
        {
            InitializeComponent();
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window menu = new Menu();
            this.Visibility = Visibility.Hidden;
            menu.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            if (EmailPlayer.Text != "" && EmailPlayer2.Text != " ")
            {
                Window Main = new MainWindow();
                this.Visibility = Visibility.Hidden;
                Main.Show();
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }
    }
}
