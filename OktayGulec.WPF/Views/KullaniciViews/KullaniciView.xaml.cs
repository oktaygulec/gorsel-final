using OktayGulec.WPF.ViewModels.KullaniciViewModels;
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
using System.Windows.Shapes;

namespace OktayGulec.WPF.Views.KullaniciViews
{
    /// <summary>
    /// Interaction logic for KullaniciView.xaml
    /// </summary>
    public partial class KullaniciView : Window
    {
        public KullaniciView(KullaniciViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            txtEPosta.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            (DataContext as KullaniciViewModel).Parola = txtParola.Password;
            DialogResult = true;
        }
    }
}
