using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace BeatEmApp
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>

    public partial class Game : Window
    {
        private ImageBrush PlayerSkin = new ImageBrush();
        private bool moveLeft, moveRight, moveUp, moveDown, moveLeft2, moveRight2, moveUp2, moveDown2, playerAttack1, playerAttack2;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private DispatcherTimer invincibleFrame = new DispatcherTimer();
        private DispatcherTimer invincibleFrame2 = new DispatcherTimer();
        private DispatcherTimer respawnTimer = new DispatcherTimer();
        private DispatcherTimer AttackTimerE1 = new DispatcherTimer();
        private DispatcherTimer AttackTimerE2 = new DispatcherTimer();

        bool Menu;

        //testen opslaan score. Wordt vervangen met echte score.
        int Testscore1;
        int testscore2;
        //int i= 0;

        int player1Health;
        int player2Health;

        private double enemySpeed = 2;
        private double enemyPosition = 0;


        bool GoLeft = true;
        bool InRange = false;
        bool GoLeft2 = true;
        bool InRange2 = false;
        bool AttackE1 = false;
        bool AttackE2 = false;

        bool gameOver1 = false;
        bool gameOver2 = false;
        //bool GoRight = false;



        public Game(String PlayerName, String Player2Name, string PlayerEmail, string Player2Email, int ScorePlayer, int scorePlayer2, int PlayerLife, int Player2Life, bool MenuOn)

        {
            InitializeComponent();

            string name = PlayerName;
            string name2 = Player2Name;


            Testscore1 = ScorePlayer;
            testscore2 = scorePlayer2;

            PlayerBar1.Value = PlayerLife;
            PlayerBar2.Value = Player2Life;

            player1Health = Convert.ToInt32(PlayerBar1.Value);
            player2Health = Convert.ToInt32(PlayerBar2.Value);

            string score = Convert.ToString(Testscore1);
            Player_contents.Text = score;

            string score2 = Convert.ToString(testscore2);
            Player2_contents.Text = score2;


            Menu = MenuOn;

            NamePlayer.Text = name;
            NamePlayer2.Text = name2;
            Player_email.Text = PlayerEmail;
            Player2_email.Text = Player2Email;





            if (MenuOn == true)
            {
                Menuscreen.Visibility = Visibility.Visible;
                menu.IsEnabled = false;
                this.Background.Opacity = 0.5;

                if (PlayerBar1.Value == 0)
                {
                    gameOver1 = true;

                    PlayerCanvas.Children.Remove(Player1);
                }

                if (PlayerBar2.Value == 0)
                {
                    gameOver2 = true;
                    PlayerCanvas.Children.Remove(Player2);
                }
            }
            else
            {
                GameTimer.Interval = TimeSpan.FromMilliseconds(20);
                GameTimer.Tick += GameEngine;
                GameTimer.Start();

                invincibleFrame.Interval = TimeSpan.FromMilliseconds(1000);
                invincibleFrame.Tick += enemy1Damage;
                invincibleFrame.Start();

                invincibleFrame2.Interval = TimeSpan.FromMilliseconds(1000);
                invincibleFrame2.Tick += enemy2Damage;
                invincibleFrame2.Start();



                respawnTimer.Interval = TimeSpan.FromSeconds(2);
                respawnTimer.Tick += RespawnEnemy;


                AttackTimerE1.Interval = TimeSpan.FromSeconds(4);
                AttackTimerE1.Tick += PlayerDamage;

                AttackTimerE2.Interval = TimeSpan.FromSeconds(4);

                AttackTimerE2.Tick += PlayerDamage;
            }


            PlayerCanvas.Focus();
        }

        public void OnClick1(object sender, RoutedEventArgs e)
        {
            Menuscreen.Visibility = Visibility.Visible;
            menu.IsEnabled = false;
            this.Background.Opacity = 0.5;
            GameTimer.Stop();
        }

        private void OnClick2(object sender, RoutedEventArgs e)
        {
            Menuscreen.Visibility = Visibility.Hidden;
            menu.IsEnabled = true;
            this.Background.Opacity = 1;

            if (Menu == true)
            {

                GameTimer.Interval = TimeSpan.FromMilliseconds(20);
                GameTimer.Tick += GameEngine;
                Menu = false;

                PlayerBar1.Value = player1Health;
                PlayerBar2.Value = player2Health;

                invincibleFrame.Interval = TimeSpan.FromMilliseconds(500);
                invincibleFrame.Tick += enemy1Damage;
                invincibleFrame.Start();

                invincibleFrame2.Interval = TimeSpan.FromMilliseconds(1000);
                invincibleFrame2.Tick += enemy2Damage;
                invincibleFrame2.Start();

                respawnTimer.Interval = TimeSpan.FromSeconds(2);
                respawnTimer.Tick += RespawnEnemy;


                AttackTimerE1.Interval = TimeSpan.FromSeconds(4);
                AttackTimerE1.Tick += PlayerDamage;

                AttackTimerE2.Interval = TimeSpan.FromSeconds(4);
                AttackTimerE2.Tick += PlayerDamage;

            }
            GameTimer.Start();

            PlayerCanvas.Focus();
        }

        private void OnClick3(object sender, RoutedEventArgs e)
        {
            LeaderBoardscreen.Visibility = Visibility.Visible;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return;
        }
        private void OnClick4(object sender, RoutedEventArgs e)
        {
            Window Quit = new Quit(NamePlayer.Text, NamePlayer2.Text, Player_email.Text, Player2_email.Text, Testscore1, testscore2, player1Health, player2Health);
            this.Visibility = Visibility.Hidden;
            Quit.Show();
        }

        private void OnClick5(object sender, RoutedEventArgs e)
        {
            LeaderBoardscreen.Visibility = Visibility.Hidden;
            datalist.Items.Clear();
        }

        private void GameEngine(object sender, EventArgs e)
        {
            
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


            player1Health = Convert.ToInt32(PlayerBar1.Value);
            player2Health = Convert.ToInt32(PlayerBar2.Value);


            Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
            Rect enemy1Rect = new Rect(Canvas.GetLeft(Enemy1), Canvas.GetTop(Enemy1), Enemy1.Width, Enemy1.Height);
            Rect enemy2Rect = new Rect(Canvas.GetLeft(Enemy2), Canvas.GetTop(Enemy2), Enemy2.Width, Enemy2.Height);

            Rect groundRect = new Rect(Canvas.GetLeft(BorderGame), Canvas.GetTop(BorderGame), BorderGame.Width, BorderGame.Height);
            Rect borderLRect = new Rect(Canvas.GetLeft(BorderLeft), Canvas.GetTop(BorderLeft), BorderLeft.Width, BorderLeft.Height);
            Rect borderRRect = new Rect(Canvas.GetLeft(BorderRight), Canvas.GetTop(BorderRight), BorderRight.Width, BorderRight.Height);
            Rect borderDRect = new Rect(Canvas.GetLeft(BorderDown), Canvas.GetTop(BorderDown), BorderDown.Width, BorderDown.Height);

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
                Canvas.SetLeft(Player1, Canvas.GetLeft(BorderRight) - 47);
            }
            if (player2Rect.IntersectsWith(borderRRect))
            {
                Canvas.SetLeft(Player2, Canvas.GetLeft(BorderRight) - 47);
            }

            if (player1Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Player1, Canvas.GetTop(BorderDown) - 68);
            }
            if (player2Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Player2, Canvas.GetTop(BorderDown) - 68);
            }

            if (EnemyBar1.Value == 0)
            {
                Enemies.Children.Remove(Enemy1Set);
                respawnTimer.Start();
            }

            if (EnemyBar2.Value == 0)
            {
                Enemies.Children.Remove(Enemy2Set);
                respawnTimer.Start();
            }

            if (AttackE1 == true)
            {
                AttackTimerE1.Start();
            }
            if (AttackE2 == true)
            {
                AttackTimerE2.Start();
            }




            enemyMovement();
            if (enemy1Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderGame));
            }
            if (enemy1Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderDown) - 68);
            }
            if (enemy2Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderGame));
            }
            if (enemy2Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderDown) - 68);
            }



            if (gameOver1 == true && gameOver2 == true)
            {
                Window GameOver = new GameOver(NamePlayer.Text, NamePlayer2.Text, Player_email.Text, Player2_email.Text, Testscore1, testscore2);
                this.Visibility = Visibility.Hidden;
                GameOver.Show();
                GameTimer.Stop();
            }

            if (PlayerBar1.Value == 0)
            {
                gameOver1 = true;

                PlayerCanvas.Children.Remove(Player1);
            }

            if (PlayerBar2.Value == 0)
            {
                gameOver2 = true;
                PlayerCanvas.Children.Remove(Player2);
            }
            
            if (AttackE1 == true)
            {
                AttackTimerE1.Start ();
            }
            if (AttackE2 == true)
            {
                AttackTimerE2.Start();
            }




            enemyMovement();
            if (enemy1Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderGame));
            }
            if (enemy1Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderDown) - 68);
            }
            if (enemy2Rect.IntersectsWith(groundRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderGame));
            }
            if (enemy2Rect.IntersectsWith(borderDRect))
            {
                Canvas.SetTop(Enemy1, Canvas.GetTop(BorderDown) - 68);
            }



            if(gameOver1 == true && gameOver2 == true)
            {
                Window GameOver = new GameOver(NamePlayer.Text, NamePlayer2.Text, Player_email.Text, Player2_email.Text, Testscore1, testscore2);
                this.Visibility = Visibility.Hidden;
                GameOver.Show();
                GameTimer.Stop();
            }

            if(PlayerBar1.Value == 0)
            {
                gameOver1 = true;
                
                PlayerCanvas.Children.Remove(Player1);
            }

            if (PlayerBar2.Value == 0)
            {
                gameOver2 = true;
                PlayerCanvas.Children.Remove(Player2);
            }

        }

        private void enemy1Damage(object sender, EventArgs e)
        {
            Rect punchHitbox = new Rect(Canvas.GetLeft(Player1) - 30, Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect punchHitbox2 = new Rect(Canvas.GetLeft(Player2) + 15, Canvas.GetTop(Player2), Player2.Width + 10, Player2.Height);



            Rect enemy1Rect = new Rect(Canvas.GetLeft(Enemy1) - 50, Canvas.GetTop(Enemy1), Enemy1.Width, Enemy1.Height);

            if (playerAttack1)
            {
                Player1.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(88, 108, 112));

                if (punchHitbox.IntersectsWith(enemy1Rect))
                {
                    Testscore1 += 50;
                    EnemyBar1.Value -= 10;
                    string score = Convert.ToString(Testscore1);
                    Player_contents.Text = score;
                }
            }

            if (playerAttack2)
            {
                Player2.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(88, 108, 112));

                if (punchHitbox2.IntersectsWith(enemy1Rect))
                {
                    testscore2 += 50;
                    EnemyBar1.Value -= 10;
                    string score = Convert.ToString(testscore2);
                    Player2_contents.Text = score;
                }
            }

        }

        private void enemy2Damage(object sender, EventArgs e)
        {
            Rect punchHitbox = new Rect(Canvas.GetLeft(Player1) - 30, Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect punchHitbox2 = new Rect(Canvas.GetLeft(Player2) + 15, Canvas.GetTop(Player2), Player2.Width + 10, Player2.Height);

            Rect enemy2Rect = new Rect(Canvas.GetLeft(Enemy2) - 50, Canvas.GetTop(Enemy2), Enemy2.Width, Enemy2.Height);



            if (playerAttack1)
            {
                Player1.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(88, 108, 112));

                if (punchHitbox.IntersectsWith(enemy2Rect))
                {
                    Testscore1 += 50;
                    EnemyBar2.Value -= 10;
                    string score = Convert.ToString(Testscore1);
                    Player_contents.Text = score;
                }
            }

            if (playerAttack2)
            {
                Player2.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(88, 108, 112));

                if (punchHitbox2.IntersectsWith(enemy2Rect))
                {
                    testscore2 += 50;
                    EnemyBar2.Value -= 10;
                    string score = Convert.ToString(testscore2);
                    Player2_contents.Text = score;
                }
            }
        }

        private void RespawnEnemy(object sender, EventArgs e)
        {
            if (EnemyBar1.Value == 0)
            {
                Enemies.Children.Add(Enemy1Set);
                EnemyBar1.Value = 30;
                respawnTimer.Stop();

            }

            if (EnemyBar2.Value == 0)
            {
                Enemies.Children.Add(Enemy2Set);
                EnemyBar2.Value = 30;
                respawnTimer.Stop();
            }
        }

        private void enemyMovement()
        {
            Rect borderLRect = new Rect(Canvas.GetLeft(BorderLeft), Canvas.GetTop(BorderLeft), BorderLeft.Width, BorderLeft.Height);
            Rect borderRRect = new Rect(Canvas.GetLeft(BorderRight), Canvas.GetTop(BorderRight), BorderRight.Width, BorderRight.Height);
            Rect enemy1Rect = new Rect(Canvas.GetLeft(Enemy1), Canvas.GetTop(Enemy1), Enemy1.Width, Enemy1.Height);
            Rect enemy2Rect = new Rect(Canvas.GetLeft(Enemy2), Canvas.GetTop(Enemy2), Enemy2.Width, Enemy2.Height);
            Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
            Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);

            var enemy1left = Canvas.GetLeft(Enemy1);
            var enemy2left = Canvas.GetLeft(Enemy2);

            var enemy1Top = Canvas.GetTop(Enemy1);
            var enemy2Top = Canvas.GetTop(Enemy2);

            var player1left = Canvas.GetLeft(Player1);
            var player2left = Canvas.GetLeft(Player2);

            var player1Top = Canvas.GetTop(Player1);
            var player2Top = Canvas.GetTop(Player2);

            var distance = new Point(player1left - enemy1left, player1Top - enemy1Top);
            




            if (enemy1Rect.IntersectsWith(player1Rect) && gameOver1 == false)
            {
                InRange = true;
            }
            else
            {
                InRange = false;
            }
            if (enemy1Rect.IntersectsWith(player2Rect) && gameOver2 == false)
            {
                InRange2 = true;
            }
            else
            {
                InRange2 = false;
            }

            if (enemy1Rect.IntersectsWith(borderLRect))
            {
                GoLeft = false;
            }
            else if (enemy1Rect.IntersectsWith(borderRRect))
            {
                GoLeft = true;
            }

            if (EnemyBar1.Value != 0)
            {
                if (InRange == false && InRange2 == false && GoLeft == true && AttackE1 == false)
                {
                    Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) - 5);
                    Canvas.SetLeft(EnemyBar1, Canvas.GetLeft(EnemyBar1) - 5);
                }
                else if (InRange == true || InRange2 == true && AttackE1 == false)
                {
                    AttackE1 = true;
                    Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) + 50);
                    Canvas.SetLeft(EnemyBar1, Canvas.GetLeft(EnemyBar1) + 50);
                    if (InRange == true)
                    {
                        PlayerBar1.Value -= 10;
                    }
                    else if (InRange2 == true)
                    {
                        PlayerBar2.Value -= 10;
                    }

                }
                else if (InRange == false && InRange2 == false && GoLeft == false && AttackE1 == false)
                {
                    Canvas.SetLeft(Enemy1, Canvas.GetLeft(Enemy1) + 5);
                    Canvas.SetLeft(EnemyBar1, Canvas.GetLeft(EnemyBar1) + 5);
                }
            }

            if (enemy2Rect.IntersectsWith(player1Rect) && gameOver2 == false)
            {
                InRange = true;
            }
            else
            {
                InRange = false;
            }

            if (enemy2Rect.IntersectsWith(player2Rect) && gameOver2 == false)
            {
                InRange2 = true;
            }
            else
            {
                InRange2 = false;
            }

            if (enemy2Rect.IntersectsWith(borderLRect))
            {
                GoLeft2 = false;
            }
            else if (enemy2Rect.IntersectsWith(borderRRect))
            {
                GoLeft2 = true;
            }
            if (EnemyBar2.Value != 0)
            {
                if (InRange == false && InRange2 == false && GoLeft2 == true && AttackE2 == false)
                {
                    Canvas.SetLeft(Enemy2, Canvas.GetLeft(Enemy2) - 5);
                    Canvas.SetLeft(EnemyBar2, Canvas.GetLeft(EnemyBar2) - 5);
                }
                else if (InRange == true || InRange2 == true && AttackE2 == false)
                {
                    AttackE2 = true;
                    Canvas.SetLeft(Enemy2, Canvas.GetLeft(Enemy2) + 50);
                    Canvas.SetLeft(EnemyBar2, Canvas.GetLeft(EnemyBar2) + 50);
                    if (InRange == true)
                    {
                        PlayerBar1.Value -= 10;
                    }
                    else if (InRange2 == true)
                    {
                        PlayerBar2.Value -= 10;
                    }

                }
                else if (InRange == false && InRange2 == false && GoLeft2 == false && AttackE2 == false)
                {
                    Canvas.SetLeft(Enemy2, Canvas.GetLeft(Enemy2) + 5);
                    Canvas.SetLeft(EnemyBar2, Canvas.GetLeft(EnemyBar2) + 5);
                }
            }


        }

        public void PlayerDamage(object sender, EventArgs e)
        {
            if (AttackE1 == true)
            {
                AttackE1 = false;
            }
            else if (AttackE2 == true)

            {
                AttackE2 = false;
            }
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.J)
            {

                moveLeft2 = true;
            }

            if (e.Key == Key.L)
            {

                moveRight2 = true;
            }

            if (e.Key == Key.I)
            {

                moveUp2 = true;

            }

            if (e.Key == Key.K)
            {
                moveDown2 = true;
            }

            if (e.Key == Key.A)
            {
                moveLeft = true;
            }

            if (e.Key == Key.D)
            {
                moveRight = true;
            }

            if (e.Key == Key.W)
            {
                moveUp = true;
            }

            if (e.Key == Key.S)
            {
                moveDown = true;
            }

            if (e.Key == Key.R)
            {
                playerAttack1 = true;
            }

            if (e.Key == Key.P)
            {
                playerAttack2 = true;
            }

            if (e.Key == Key.Enter)
            {
                Window GameOver = new GameOver(NamePlayer.Text, NamePlayer2.Text, Player_email.Text, Player2_email.Text, Testscore1, testscore2);
                this.Visibility = Visibility.Hidden;
                GameOver.Show();
            }

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.J)
            {
                moveLeft2 = false;
            }

            if (e.Key == Key.L)
            {
                moveRight2 = false;
            }

            if (e.Key == Key.I)
            {
                moveUp2 = false;
            }

            if (e.Key == Key.K)
            {
                moveDown2 = false;
            }

            if (e.Key == Key.R)
            {
                playerAttack1 = false;
                Player1.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(109, 127, 172));
            }

            if (e.Key == Key.A)
            {
                moveLeft = false;
            }

            if (e.Key == Key.D)
            {
                moveRight = false;
            }

            if (e.Key == Key.W)
            {
                moveUp = false;
            }

            if (e.Key == Key.S)
            {
                moveDown = false;
            }

            if (e.Key == Key.P)
            {
                playerAttack2 = false;
                Player2.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(109, 127, 172));
            }
        }
    }
}