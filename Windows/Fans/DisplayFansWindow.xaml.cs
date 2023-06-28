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

namespace Football_Fan_Manager.Windows.Fans
{
    /// <summary>
    /// Interaction logic for DisplayFansWindow.xaml
    /// </summary>
    public partial class DisplayFansWindow : Window
    {
        private IFanRepository fanRepository;

        public DisplayFansWindow()
        {
            InitializeComponent();
            fanRepository = new FanRepository();
            FansDataGrid.ItemsSource = fanRepository.GetFans();
        }

        private void AddFan_Button_Click(object sender, RoutedEventArgs e)
        {
            AddFanWindow addFanWindow = new AddFanWindow();
            addFanWindow.Closing += AddFanWindow_Closing;

            addFanWindow.ShowDialog();
        }

        private void AddFanWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FansDataGrid.ItemsSource = fanRepository.GetFans();
        }

        private void EditFan_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = FansDataGrid.SelectedItem as Fan;

            if (selectedRow != null)
            {
                UpdateFanWindow updateFanWindow = new UpdateFanWindow(selectedRow);
                updateFanWindow.Closing += UpdateFanWindow_Closing;

                updateFanWindow.ShowDialog();
            }
        }

        private void UpdateFanWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FansDataGrid.ItemsSource = fanRepository.GetFans();
        }

        private void DeleteFan_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = FansDataGrid.SelectedItem as Fan;

            if (selectedRow != null)
            {
                fanRepository.DeleteFan(selectedRow.Id);
                FansDataGrid.ItemsSource = fanRepository.GetFans();
            }
        }

        private void FavoriteClubs_Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = FansDataGrid.SelectedItem as Fan;

            if (selectedRow != null)
            {
                FavoriteClubsWindow favoriteClubsWindow = new FavoriteClubsWindow(selectedRow.Id, selectedRow.Name, selectedRow.Surname);
                favoriteClubsWindow.ShowDialog();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
