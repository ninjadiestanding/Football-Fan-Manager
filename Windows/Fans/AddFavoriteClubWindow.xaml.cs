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
    /// Interaction logic for AddFavoriteClubWindow.xaml
    /// </summary>
    public partial class AddFavoriteClubWindow : Window
    {
        private IClubRepository clubRepository;
        private IFanRepository fanRepository;

        private readonly int FanId;
        public AddFavoriteClubWindow(int fanId)
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            fanRepository = new FanRepository();
            FanId = fanId;

            ClubComboBox.ItemsSource = fanRepository.GetClubsWithoutFavorite(FanId);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedClub = ClubComboBox.SelectedItem as Club;

            if (selectedClub != null)
            {
                fanRepository.AddFavoriteClub(FanId, selectedClub.Id);

                this.Close();
            }
            else
            {
                MessageBox.Show("Choose your favorite club to add and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
