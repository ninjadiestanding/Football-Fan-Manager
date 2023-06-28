using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Implementation;
using Football_Fan_Manager.Services.Interfaces;
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

namespace Football_Fan_Manager.Windows.Clubs
{
    /// <summary>
    /// Interaction logic for DisplayClubPlayersWindow.xaml
    /// </summary>
    public partial class DisplayClubPlayersWindow : Window
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;
        private readonly int ClubId;

        public DisplayClubPlayersWindow(int clubId)
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            playerRepository = new PlayerRepository();

            ClubId = clubId;
            ClubPlayersDataGrid.ItemsSource = clubRepository.GetPlayersForClub(ClubId);
        }

        private void AddPlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerToClubWIndow addPlayerToClubWIndow = new AddPlayerToClubWIndow(ClubId);
            addPlayerToClubWIndow.Closing += AddPlayerToClubWIndow_Closing;

            addPlayerToClubWIndow.ShowDialog();
        }

        private void AddPlayerToClubWIndow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClubPlayersDataGrid.ItemsSource = clubRepository.GetPlayersForClub(ClubId);
        }

        private void ExcludePlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = ClubPlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                playerRepository.ExcludePlayerFromClub(selectedRow.Id);
                ClubPlayersDataGrid.ItemsSource = clubRepository.GetPlayersForClub(ClubId);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
