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

namespace FitClubCurse.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для SubP.xaml
    /// </summary>
    public partial class SubP : Page
    {
        public SubP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.subscription.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                App.DB.subscription.Remove(selectedSub);
                App.DB.SaveChanges();
                SubscrDG.ItemsSource = App.DB.subscription.ToList();
            }
            else MessageBox.Show("Выберите абонемент");
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

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSubP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                NavigationService.Navigate(new EditSubP(selectedSub));
            }
            else MessageBox.Show("Выберите абонемент");
            
        }
    }
}
