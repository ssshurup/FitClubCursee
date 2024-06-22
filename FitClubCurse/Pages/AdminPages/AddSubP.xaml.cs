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
    /// Логика взаимодействия для AddSubP.xaml
    /// </summary>
    public partial class AddSubP : Page
    {
        subscription context;
        public AddSubP()
        {
            InitializeComponent();
            TypeCB.ItemsSource = App.DB.access.ToList();
            context = new subscription();
            DataContext = context;
        }


        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.DB.subscription.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new SubP());

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
