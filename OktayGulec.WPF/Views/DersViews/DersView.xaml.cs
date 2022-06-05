using OktayGulec.WPF.ViewModels.DersViewModels;
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

namespace OktayGulec.WPF.Views.DersViews
{
    /// <summary>
    /// Interaction logic for DersView.xaml
    /// </summary>
    public partial class DersView : Window
    {
        public DersView(DersViewModel vm)
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
            txtVize.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtFinal.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbHocalar.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            DialogResult = true;
        }
    }
}
