using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Implementation;
using Football_Fan_Manager.Services.Interfaces;
using Football_Fan_Manager.Windows.Clubs;
using Football_Fan_Manager.Windows.Fans;
using Football_Fan_Manager.Windows.Players;
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

namespace Football_Fan_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IClubRepository clubRepository;

        public MainWindow()
        {
            InitializeComponent();

            clubRepository = new ClubRepository();
        }

        private void Clubs_Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayClubsWindow displayClubsWindow = new DisplayClubsWindow();
            displayClubsWindow.ShowDialog();
        }

        private void Players_Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayPlayersWindow displayPlayersWindow = new DisplayPlayersWindow();
            displayPlayersWindow.ShowDialog();
        }

        private void Fans_Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayFansWindow displayFansWindow = new DisplayFansWindow();
            displayFansWindow.ShowDialog();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
