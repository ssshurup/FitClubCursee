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
    /// Логика взаимодействия для EmployeeP.xaml
    /// </summary>
    public partial class EmployeeP : Page
    {
        public EmployeeP()
        {
            InitializeComponent();
                EmpDG.ItemsSource = App.DB.employee.ToList();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            employee emp = new employee();
            NavigationService.Navigate(new AddEmpP(emp));
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmpDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
                App.DB.employee.Remove(selectedEmp);
                App.DB.SaveChanges();
                EmpDG.ItemsSource = App.DB.employee.ToList();
            }
            else MessageBox.Show("Выберите работника");
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmpDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
                NavigationService.Navigate(new AddEmpP(selectedEmp));
            }
            else MessageBox.Show("Выберите работника");
        }

        private void LessonBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }
    }
}
