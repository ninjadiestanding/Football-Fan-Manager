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
using static System.Net.Mime.MediaTypeNames;

namespace Football_Fan_Manager.Windows.Clubs
{
    /// <summary>
    /// Interaction logic for AddClubWindow.xaml
    /// </summary>
    public partial class AddClubWindow : Window
    {
        private IClubRepository clubRepository;
        public AddClubWindow()
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(NameTextBox.Text)) && !(string.IsNullOrWhiteSpace(CityTextBox.Text)))
            {
                clubRepository.AddClub(new Club(NameTextBox.Text, CityTextBox.Text));
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
