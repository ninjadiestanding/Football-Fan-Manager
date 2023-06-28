using Football_Fan_Manager.Models;
using Football_Fan_Manager.Services.Implementation;
using Football_Fan_Manager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for UpdateFanWindow.xaml
    /// </summary>
    public partial class UpdateFanWindow : Window
    {
        private IFanRepository fanRepository;
        private Fan fan;
        public UpdateFanWindow(Fan selectedFan)
        {
            InitializeComponent();
            fanRepository = new FanRepository();
            fan = selectedFan;

            NameTextBox.Text = fan.Name;
            SurnameTextBox.Text = fan.Surname;
            PatronymicTextBox.Text = fan.Patronymic;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(NameTextBox.Text)) && !(string.IsNullOrWhiteSpace(SurnameTextBox.Text)))
            {
                fanRepository.UpdateFan(new Fan(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text) { Id = fan.Id });
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
