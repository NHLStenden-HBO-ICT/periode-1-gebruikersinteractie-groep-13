﻿using System;
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
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver()
        {
            InitializeComponent();
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window Game = new Game();
            this.Visibility = Visibility.Hidden;
            Game.Show();
        }

        public void OnClick2(object sender, RoutedEventArgs e)
        {
            Window Main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            Main.Show();
        }
    }
}
