﻿using Microsoft.Win32;
using FitClubCurse.Pages.ClientPages;
using FitClubCurse.Pages.AdminPages;
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

namespace FitClubCurse.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        users context;
        public LoginP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterP());
        }

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            var tryLogin = App.DB.users.Where(a => a.login == context.login && a.password == context.password);
            if (tryLogin.Any())
            {
                App.LoggedUser = tryLogin.First();
                if (App.LoggedUser.idRole == 1)
                {
                    NavigationService.Navigate(new AdminP());
                }
                else NavigationService.Navigate(new ClientP());
            }
            else MessageBox.Show("Неверный логин или пароль");
        }
    }
}
