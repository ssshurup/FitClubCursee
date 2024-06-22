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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitClubCurse.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для ProfileP.xaml
    /// </summary>
    public partial class ProfileP : Page
    {
        users context;
        public ProfileP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
            BalanceTB.Text += App.LoggedUser.balance;
            context = App.LoggedUser;
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as hystory;
            if(selectedSub != null)
            {
                App.DB.hystory.Remove(selectedSub);
                App.DB.SaveChanges();
                MessageBox.Show("Аббонемент отменён");
                SubscrDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
            }
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                string message = "";
                message += "Название: " + selectedSub.name;
                message += "\nЦена: " + selectedSub.price;
                message += "\nТип: " + selectedSub.access.name;
                message += "\nОписание: " + selectedSub.description;
                MessageBox.Show(message);
            }
            else MessageBox.Show("Выберите абонемент");
        }

        private void AddBalance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBalanceP());
        }
    }
}
