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

namespace OktayGulec.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDersList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/DersViews/DersListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnHocaList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/HocaViews/HocaListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnKullaniciList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/KullaniciViews/KullaniciListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }
    }
}
