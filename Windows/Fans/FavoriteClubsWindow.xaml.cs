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

namespace Football_Fan_Manager.Windows.Fans
{
    /// <summary>
    /// Interaction logic for FavoriteClubsWindow.xaml
    /// </summary>
    public partial class FavoriteClubsWindow : Window
    {
        private IFanRepository fanRepository;
        private readonly int FanId;
        public FavoriteClubsWindow(int fanId, string fanName, string fanSurname)
        {
            InitializeComponent();
            fanRepository = new FanRepository();
            FanId = fanId;

            ClubsDataGrid.ItemsSource = fanRepository.GetFavoriteClubs(FanId);
            headerLabel.Content = $"{fanName} {fanSurname}'s favorite clubs";
        }

        private void AddClub_Button_Click(object sender, RoutedEventArgs e)
        {
            AddFavoriteClubWindow addFavoriteClubWindow = new AddFavoriteClubWindow(FanId);
            addFavoriteClubWindow.Closing += AddFavoriteClubWindow_Closing;

            addFavoriteClubWindow.ShowDialog();
        }

        private void AddFavoriteClubWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClubsDataGrid.ItemsSource = fanRepository.GetFavoriteClubs(FanId);
        }

        private void ExcludeClub_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = ClubsDataGrid.SelectedItem as Club;

            if (selectedRow != null)
            {
                fanRepository.ExcludeFavoriteClub(FanId, selectedRow.Id);

                ClubsDataGrid.ItemsSource = fanRepository.GetFavoriteClubs(FanId);
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
