using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Implementation;
using Football_Fan_Manager.Services.Interfaces;
using Football_Fan_Manager.Windows.Clubs;
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
    /// Interaction logic for DisplayPlayersWindow.xaml
    /// </summary>
    public partial class DisplayPlayersWindow : Window
    {
        private IPlayerRepository playerRepository;

        public DisplayPlayersWindow()
        {
            InitializeComponent();
            playerRepository = new PlayerRepository();
            PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
        }

        private void AddPlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow addPlayerWindow = new AddPlayerWindow();
            addPlayerWindow.Closing += AddPlayerWindow_Closing;

            addPlayerWindow.ShowDialog();
        }

        private void AddPlayerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
        }

        private void EditPlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = PlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                UpdatePlayerWindow updatePlayerWindow = new UpdatePlayerWindow(selectedRow);
                updatePlayerWindow.Closing += UpdatePlayerWindow_Closing;

                updatePlayerWindow.ShowDialog();
            }
        }

        private void UpdatePlayerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
        }

        private void DeletePlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = PlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                playerRepository.DeletePlayer(selectedRow.Id);
                PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
            }
        }

        private void TransferPlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = PlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                TransferPlayerWindow transferPlayerWindow = new TransferPlayerWindow(selectedRow.Id);
                transferPlayerWindow.Closing += TransferPlayerWindow_Closing;

                transferPlayerWindow.ShowDialog();
            }
        }

        private void TransferPlayerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
        }

        private void LeavePlayer_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = PlayersDataGrid.SelectedItem as Player;

            if (selectedRow != null)
            {
                playerRepository.ExcludePlayerFromClub(selectedRow.Id);
                PlayersDataGrid.ItemsSource = playerRepository.GetPlayers();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
