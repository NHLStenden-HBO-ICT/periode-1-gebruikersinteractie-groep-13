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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        public void OnClick3(object sender, RoutedEventArgs e)
        {
            Window Help = new Help();
            this.Visibility = Visibility.Hidden;
            Help.Show();
        }

    }
}
