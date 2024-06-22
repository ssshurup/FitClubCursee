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
    /// Логика взаимодействия для BuySubP.xaml
    /// </summary>
    public partial class BuySubP : Page
    {
        public BuySubP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.subscription.ToList();
            SortCB.ItemsSource = App.DB.access.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }

        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                if(App.LoggedUser.balance < selectedSub.price)
                {
                    MessageBox.Show("Недостаточно средств");
                    return;
                }
                else
                {
                    hystory tranzaction = new hystory();
                    tranzaction.idUser = App.LoggedUser.id;
                    tranzaction.dateStart = DateTime.Now;
                    tranzaction.dateEnd = DateTime.Now.AddMonths(1);
                    tranzaction.idSub = selectedSub.id;
                    App.DB.hystory.Add(tranzaction);
                    App.LoggedUser.balance -= selectedSub.price;
                    App.DB.SaveChanges();
                    MessageBox.Show("Абонемент куплен");
                }
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
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAccess = SortCB.SelectedItem as access;
            SubscrDG.ItemsSource = App.DB.subscription.Where(a => a.idAccess == selectedAccess.id).ToList();
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuySubP());
        }
    }
}
