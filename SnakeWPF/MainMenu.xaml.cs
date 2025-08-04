using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainMeni.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        MainWindow mainWindow;
        public MainMenu(MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        public void StartGame()
        {
            mainWindow.contentControl.Visibility = Visibility.Hidden;
            mainWindow.gameGrid.Visibility = Visibility.Visible;
            mainWindow.sControl.ApplyLastSettings();

            mainWindow.video.Stop();
            mainWindow.video.Visibility = Visibility.Hidden;

            mainWindow.Process();
        }

        private void buttonSettings_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.sControl.ApplyLastSettings();
            mainWindow.contentControl.Content = mainWindow.sControl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
