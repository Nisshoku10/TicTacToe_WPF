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

namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        public GameMenu()
        {
            InitializeComponent();
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void AboutGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"This is redeveloped by Juswa!");
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
