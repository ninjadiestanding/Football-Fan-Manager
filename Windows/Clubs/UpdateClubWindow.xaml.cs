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
    /// Interaction logic for UpdateClubWindow.xaml
    /// </summary>
    public partial class UpdateClubWindow : Window
    {
        private IClubRepository clubRepository;
        private Club club;
        public UpdateClubWindow(Club selectedClub)
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            club = selectedClub;

            NameTextBox.Text = club.Name;
            CityTextBox.Text = club.City;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(NameTextBox.Text)) && !(string.IsNullOrWhiteSpace(CityTextBox.Text)))
            {
                clubRepository.UpdateClub(new Club(NameTextBox.Text, CityTextBox.Text) { Id = club.Id });
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly and try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
