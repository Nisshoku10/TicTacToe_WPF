using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string move = "X";
        private int playerXwins = 0;
        private int playerOwins = 0;
        private int round = 1;
        private static readonly Brush defBrush = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));
        //Open Window
        public MainWindow()
        {
            InitializeComponent();
        }

        // Menu Items 
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            playerXwins = 0;
            playerOwins = 0;
            XWins.Content = "X: 0";
            OWins.Content = "O: 0";
            RoundCount.Content = "Round 1";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"This is redeveloped by Juswa!");
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            GameMenu GameMenu = new GameMenu();
            Visibility = Visibility.Hidden;
            GameMenu.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;

            if (bt.Content.ToString() == "X")
            {
                Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }
            else if (bt.Content.ToString() == "O")
            {
                Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }

            //Rows
            if (isWinning(Btn1, Btn2, Btn3))
            {
                GameOver(Btn1.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }
            else if (isWinning(Btn4, Btn5, Btn6))
            {
                GameOver(Btn4.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }
            else if (isWinning(Btn7, Btn8, Btn9))
            {
                GameOver(Btn7.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }

            //Columns
            else if (isWinning(Btn1, Btn4, Btn7))
            {
                GameOver(Btn1.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }
            else if (isWinning(Btn2, Btn5, Btn8))
            {
                GameOver(Btn2.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }

            else if (isWinning(Btn3, Btn6, Btn9))
            {
                GameOver(Btn3.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }

            //Diagonals
            else if (isWinning(Btn1, Btn5, Btn9))
            {
                GameOver(Btn1.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }

            else if (isWinning(Btn3, Btn5, Btn7))
            {
                GameOver(Btn3.Content.ToString());
                RoundCount.Content = $"Round {round++}";
            }

            else if (!Btn1.IsEnabled && !Btn2.IsEnabled && !Btn3.IsEnabled &&
                !Btn4.IsEnabled && !Btn5.IsEnabled && !Btn6.IsEnabled &&
                !Btn7.IsEnabled && !Btn8.IsEnabled && !Btn9.IsEnabled)
            {
                GameOver("");
                RoundCount.Content = $"Round {round++}";
            }

            //Check whether player X or O
            move = move == "X" ? "O" : "X";
        }

        private bool isWinning(Button btn1, Button bt2, Button bt3) =>
            !btn1.IsEnabled && btn1.Content == bt2.Content && btn1.Content == bt3.Content;

        private void GameOver(string? winner)
        {
            if (Winner.Visibility == Visibility.Visible) return;
            if (winner == "X")
            {
                Winner.Content = "Player X Wins!";
                XWins.Content = $"X: {++playerXwins}";
            }
            else if (winner == "O")
            {
                Winner.Content = "Player O Wins!";
                OWins.Content = $"O: {++playerOwins}";
            }
            else
            {
                Winner.Content = "It's a tie!";
            }
            Winner.Visibility = Visibility.Visible;
            WaitToRestartGame();
        }

        private async void WaitToRestartGame()
        {
            await Task.Delay(1000);
            Winner.Visibility = Visibility.Hidden;
            ResetButtons();
        }

        private void ResetButtons()
        {
            ResetButton(Btn1);
            ResetButton(Btn2);
            ResetButton(Btn3);
            ResetButton(Btn4);
            ResetButton(Btn5);
            ResetButton(Btn6);
            ResetButton(Btn7);
            ResetButton(Btn8);
            ResetButton(Btn9);
        }

        private void ResetButton(Button bt)
        {
            bt.Content = "";
            bt.IsEnabled = true;
            bt.Foreground = defBrush;
        }

        private void Btn_Enter(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = move;
        }

        private void Btn_Leave(object sender, MouseEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled)
            {
                bt.Content = "";
            }
        }

        private void RestartClick2(object sender, RoutedEventArgs e)
        {
            ResetButtons();
        }
    }
}