using OktayGulec.WPF.ViewModels.HocaViewModels;
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

namespace OktayGulec.WPF.Views.HocaViews
{
    /// <summary>
    /// Interaction logic for HocaView.xaml
    /// </summary>
    public partial class HocaView : Window
    {
        public HocaView(HocaViewModel vm)
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
            txtAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DialogResult = true;
        }
    }
}
