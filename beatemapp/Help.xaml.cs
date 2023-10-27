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
using System.Windows.Threading;

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    /// 


    public partial class Help : Window
    {
        private ImageBrush PlayerSkin = new ImageBrush();
        private bool moveLeft, moveRight, moveUp, moveDown, moveLeft2, moveRight2, moveUp2, moveDown2;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        
        public Help()
        {
            InitializeComponent();
        }


        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window Main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            Main.Show();
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                moveLeft2 = true;
            }

            if (e.Key == Key.D)
            {
                moveRight2 = true;
            }

            if (e.Key == Key.W)
            {
                moveUp2 = true;
            }

            if (e.Key == Key.S)
            {
                moveDown2 = true;
            }

            if (e.Key == Key.J)
            {
                moveLeft = true;
            }

            if (e.Key == Key.L)
            {
                moveRight = true;
            }

            if (e.Key == Key.I)
            {
                moveUp = true;
            }

            if (e.Key == Key.K)
            {
                moveDown = true;
            }

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                moveLeft2 = false;
            }

            if (e.Key == Key.D)
            {
                moveRight2 = false;
            }

            if (e.Key == Key.W)
            {
                moveUp2 = false;
            }

            if (e.Key == Key.S)
            {
                moveDown2 = false;
            }

            if (e.Key == Key.J)
            {
                moveLeft = false;
            }

            if (e.Key == Key.L)
            {
                moveRight = false;
            }

            if (e.Key == Key.I)
            {
                moveUp = false;
            }

            if (e.Key == Key.K)
            {
                moveDown = false;
            }
        }
    }
}
