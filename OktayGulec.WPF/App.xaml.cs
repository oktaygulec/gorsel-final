using OktayGulec.WPF.Views.KullaniciViews;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OktayGulec.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            MainWindow mainWindow = new MainWindow();

            if (loginWindow.ShowDialog() == true)
            {
                mainWindow.Show();
            }

        }
    }
}
