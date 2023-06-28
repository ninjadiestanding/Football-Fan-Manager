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

namespace Football_Fan_Manager.Windows.Players
{
    /// <summary>
    /// Interaction logic for TransferPlayerWindow.xaml
    /// </summary>
    public partial class TransferPlayerWindow : Window
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;

        private readonly int PlayerId;
        public TransferPlayerWindow(int playerId)
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            playerRepository = new PlayerRepository();
            PlayerId = playerId;

            ClubComboBox.ItemsSource = clubRepository.GetClubs();
        }

        private void Transfer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClub = ClubComboBox.SelectedItem as Club;

            if (selectedClub != null)
            {
                int? clubId = selectedClub?.Id;

                playerRepository.AddPlayerToClub(PlayerId, clubId);

                this.Close();
            }
            else
            {
                MessageBox.Show("Select a transfer club and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
