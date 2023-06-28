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
    /// Interaction logic for AddPlayerToClubWIndow.xaml
    /// </summary>
    public partial class AddPlayerToClubWIndow : Window
    {
        private IPlayerRepository playerRepository;
        private readonly int ClubId;

        public AddPlayerToClubWIndow(int clubId)
        {
            InitializeComponent();
            playerRepository = new PlayerRepository();

            ClubId = clubId;
            PlayersDataGrid.ItemsSource = playerRepository.GetPlayersWithoutClub();
        }


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = PlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                playerRepository.AddPlayerToClub(selectedRow.Id, ClubId);
                this.Close();
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
