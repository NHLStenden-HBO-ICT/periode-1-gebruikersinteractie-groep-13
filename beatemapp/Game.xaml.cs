﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Game.xaml
    /// </summary>

    public partial class Game : Window
    {
        private ImageBrush PlayerSkin = new ImageBrush();
        private bool moveLeft, moveRight, moveUp, moveDown, moveLeft2, moveRight2, moveUp2, moveDown2, playerAttack1;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        public Game()
        {
            InitializeComponent();

            GameTimer.Interval = TimeSpan.FromMilliseconds(20);
            GameTimer.Tick += GameEngine;
            GameTimer.Start();

            PlayerCanvas.Focus();
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Window Menu = new Menu();
            this.Visibility = Visibility.Hidden;
            Menu.Show();
        }

        private void GameEngine(object sender, EventArgs e)
        {
            int player1Health = 100;
            int player2Health = 100;
            int enemyHealth = 100;




            if (moveLeft)
                Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) - 10);
            if (moveRight)
                Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) + 10);
            if (moveUp)
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) - 7);
            if (moveDown)
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) + 7);
            if (moveLeft2)
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) - 10);
            if (moveRight2)
                Canvas.SetLeft(Player2, Canvas.GetLeft(Player2) + 10);
            if (moveUp2)
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) - 7);
            if (moveDown2)
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) + 7);

            
            
            



            Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
            Rect enemy1Rect = new Rect(Canvas.GetLeft(Enemy1), Canvas.GetTop(Enemy1), Enemy1.Width, Enemy1.Height);
            Rect groundRect = new Rect(Canvas.GetLeft(BorderGame), Canvas.GetTop(BorderGame), BorderGame.Width, BorderGame.Height);
            Rect borderLRect = new Rect(Canvas.GetLeft(BorderLeft), Canvas.GetTop(BorderLeft), BorderLeft.Width, BorderLeft.Height);
            Rect borderRRect = new Rect(Canvas.GetLeft(BorderRight), Canvas.GetTop(BorderRight), BorderRight.Width, BorderRight.Height);
            Rect borderDRect = new Rect(Canvas.GetLeft(BorderDown), Canvas.GetTop(BorderDown), BorderDown.Width, BorderDown.Height);

            /*BorderL = Linkerkant van de game scherm
              BorderR = Rechterkant van de game scherm
              BorderD = Onderkant van de game scherm */
             

            //hieronder alle barrieres voor de muren
            if (player1Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Player1, Canvas.GetTop(BorderGame));
            }
            if (player2Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Player2, Canvas.GetTop(BorderGame));
            }

            if (player1Rect.IntersectsWith(borderLRect))
            {
                Canvas.SetLeft(Player1, Canvas.GetLeft(BorderLeft));
            }
            if (player2Rect.IntersectsWith(borderLRect))
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(BorderLeft));
            }

            if (player1Rect.IntersectsWith(borderRRect))
            {
                Canvas.SetLeft(Player1, Canvas.GetLeft(BorderRight) - 61);
            }
            if (player2Rect.IntersectsWith(borderRRect))
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(BorderRight) - 61);
            }

            if (player1Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Player1, Canvas.GetTop(BorderDown) - 90);
            }
            if (player2Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Player2, Canvas.GetTop(BorderDown) - 90);
            }

            Rect punchHitbox = new Rect(Canvas.GetLeft(Player1) - 50, Canvas.GetTop(Player1), Player1.Width - 50, Player1.Height - 50);
            

            if (punchHitbox.IntersectsWith(enemy1Rect))
            {
                enemyHealth =- 10;
            }

            string enemyhealthDisplay = "Health: " + Convert.ToString(enemyHealth);

        }
        private void enemyMovement()
        {
            var enemy1left = Canvas.GetLeft(Enemy1);
            var enemy2left = Canvas.GetLeft(Enemy2);

            var enemy1Top = Canvas.GetTop(Enemy1);
            var enemy2Top = Canvas.GetTop(Enemy2);

            var player1left = Canvas.GetLeft(Player1);
            var player2left = Canvas.GetLeft(Player2);

            var player1Top = Canvas.GetTop(Player1);
            var player2Top = Canvas.GetTop(Player2);

            var distance = new Point(player1left - enemy1left, player1Top - enemy1Top);

            if (distance.X > 0 && distance.Y > 0)
            {

                Canvas.SetTop(Enemy1, Canvas.GetTop(Enemy1) + 10);
                Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) + 10);

            }
            else if (distance.X < 0 && distance.Y < 0)
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(Enemy1) - 10);
                Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) - 10);
            }
            else if (distance.X > 0 && distance.Y < 0)
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(Enemy1) - 10);
                Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) + 10);

            }
            else if (distance.X < 0 && distance.Y > 0)
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(Enemy1) + 10);
                Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) - 10);
            }
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

            if (e.Key == Key.Enter)
            {
                Window GameOver = new GameOver();
                this.Visibility = Visibility.Hidden;
                GameOver.Show();
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
                moveRight= false;
            }

            if (e.Key == Key.I)
            {
                moveUp= false;
            }

            if (e.Key == Key.K)
            {
                moveDown= false;
            }
        }
    }
}
