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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void OnClick1(object sender, RoutedEventArgs e)
        {
           Window Game = new Game();
           this.Visibility = Visibility.Hidden;
           Game.Show();
        }

        private void OnClick2(object sender, RoutedEventArgs e)
        {
            Window Leader = new Leaderboard();
            this.Visibility = Visibility.Hidden;
            Leader.Show();
        }

        private void OnClick3(object sender, RoutedEventArgs e)
        {
            Window Quit = new Quit();
            this.Visibility = Visibility.Hidden;
            Quit.Show();
        }
    }
}
