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
    /// Логика взаимодействия для ClientP.xaml
    /// </summary>
    public partial class ClientP : Page
    {
        public ClientP()
        {
            InitializeComponent();
            UserNameTB.Text += App.LoggedUser.name;
        }

        private void ProfileBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileP());
        }

        private void BalanceBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBalanceP());
        }

        private void BuySubBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuySubP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }
    }
}
