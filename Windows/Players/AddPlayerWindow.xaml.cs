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
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        private IPlayerRepository playerRepository;
        private IClubRepository clubRepository;
        public AddPlayerWindow()
        {
            InitializeComponent();
            playerRepository = new PlayerRepository();
            clubRepository = new ClubRepository();

            ClubComboBox.ItemsSource = clubRepository.GetClubs();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(NameTextBox.Text)) && !(string.IsNullOrWhiteSpace(SurnameTextBox.Text)) && 
                !(string.IsNullOrWhiteSpace(DateOfBirthDataPicker.SelectedDate?.ToString())))
            {
                if ((SnilsTextBox.Text.Length == 11 && SnilsTextBox.Text.All(char.IsDigit)))
                {
                    var selectedClub = ClubComboBox.SelectedItem as Club;
                    int? clubId = selectedClub?.Id;

                    playerRepository.AddPlayer(new Player(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text,
                        DateOfBirthDataPicker.SelectedDate.Value, Convert.ToInt64(SnilsTextBox.Text), clubId));

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Snils field must contain 11 digits", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
