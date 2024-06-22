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
    /// Логика взаимодействия для LessonP.xaml
    /// </summary>
    public partial class LessonP : Page
    {
        public LessonP()
        {
            InitializeComponent();
                LessonDG.ItemsSource = App.DB.lesson.ToList();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            lesson les = new lesson();
            NavigationService.Navigate(new AddLessonP(les));

        }


        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedLes = LessonDG.SelectedItem as lesson;
            if (selectedLes != null)
            {
               App.DB.lesson.Remove(selectedLes);
                App.DB.SaveChanges();
                LessonDG.ItemsSource = App.DB.lesson.ToList();
            }
            else MessageBox.Show("Выберите занятие");
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedLes = LessonDG.SelectedItem as lesson;
            if (selectedLes != null)
            {
                NavigationService.Navigate(new AddLessonP(selectedLes));
            }
            else MessageBox.Show("Выберите занятие");
        }
    }
}
