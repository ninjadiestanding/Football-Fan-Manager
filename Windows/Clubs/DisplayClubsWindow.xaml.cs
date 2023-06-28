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
    /// Interaction logic for DisplayClubsWindow.xaml
    /// </summary>
    public partial class DisplayClubsWindow : Window
    {
        private IClubRepository clubRepository;

        public DisplayClubsWindow()
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            ClubsDataGrid.ItemsSource = clubRepository.GetClubs();
        }

        private void AddClub_Button_Click(object sender, RoutedEventArgs e)
        {
            AddClubWindow addClubWindow = new AddClubWindow();
            addClubWindow.Closing += AddClubWindow_Closing;

            addClubWindow.ShowDialog();
        }

        private void AddClubWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClubsDataGrid.ItemsSource = clubRepository.GetClubs();
        }

        private void EditClub_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = ClubsDataGrid.SelectedItem as Club;

            if (selectedRow != null)
            {
                UpdateClubWindow updateClubWindow = new UpdateClubWindow(selectedRow);
                updateClubWindow.Closing += UpdateClubWindow_Closing;

                updateClubWindow.ShowDialog();
            }
        }

        private void UpdateClubWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClubsDataGrid.ItemsSource = clubRepository.GetClubs();
        }

        private void DeleteClub_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = ClubsDataGrid.SelectedItem as Club;

            if (selectedRow != null)
            {
                clubRepository.DeleteClub(selectedRow.Id);
                ClubsDataGrid.ItemsSource = clubRepository.GetClubs();
            }
        }

        private void ClubPlayers_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = ClubsDataGrid.SelectedItem as Club;

            if (selectedRow != null)
            {
                DisplayClubPlayersWindow displayClubPlayersWindow = new DisplayClubPlayersWindow(selectedRow.Id, selectedRow.Name);
                displayClubPlayersWindow.ShowDialog();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
