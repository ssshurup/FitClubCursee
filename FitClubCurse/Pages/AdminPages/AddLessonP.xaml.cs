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
    /// Логика взаимодействия для AddLessonP.xaml
    /// </summary>
    public partial class AddLessonP : Page
    {
        lesson context;
        public AddLessonP(lesson les)
        {
            InitializeComponent();
            ClientCB.ItemsSource = App.DB.users.Where(a => a.idRole == 2).ToList();
            EmpCB.ItemsSource = App.DB.employee.ToList();
            context = les;
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0)
                    App.DB.lesson.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new LessonP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonP());
        }
    }
}
