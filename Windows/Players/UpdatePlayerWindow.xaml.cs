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
    /// Interaction logic for UpdatePlayerWindow.xaml
    /// </summary>
    public partial class UpdatePlayerWindow : Window
    {
        private IPlayerRepository playerRepository;
        private IClubRepository clubRepository;
        private Player player;
        public UpdatePlayerWindow(Player selectedPlayer)
        {
            InitializeComponent();
            playerRepository = new PlayerRepository();
            clubRepository = new ClubRepository();
            player = selectedPlayer;
            this.DataContext = player;

            NameTextBox.Text = player.Name;
            SurnameTextBox.Text = player.Surname;
            PatronymicTextBox.Text = player.Patronymic;
            DateOfBirthDataPicker.SelectedDate = (DateTime?)player.DateOfBirth;
            SnilsTextBox.Text = Convert.ToString(player.Snils);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            


            if (!(string.IsNullOrWhiteSpace(NameTextBox.Text)) && !(string.IsNullOrWhiteSpace(SurnameTextBox.Text)) &&
                !(string.IsNullOrWhiteSpace(DateOfBirthDataPicker.SelectedDate?.ToString())))
            {
                if ((SnilsTextBox.Text.Length == 11 && SnilsTextBox.Text.All(char.IsDigit)))
                {
                    playerRepository.UpdatePlayer(new Player(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text,
                        DateOfBirthDataPicker.SelectedDate.Value, Convert.ToInt64(SnilsTextBox.Text), player.ClubId) { Id = player.Id });
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
