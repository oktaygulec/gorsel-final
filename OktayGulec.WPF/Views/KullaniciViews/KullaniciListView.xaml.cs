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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OktayGulec.WPF.Views.KullaniciViews
{
    /// <summary>
    /// Interaction logic for KullaniciListView.xaml
    /// </summary>
    public partial class KullaniciListView : Page
    {
        public KullaniciListView()
        {
            InitializeComponent();
            DataContext = new KullaniciListViewModel();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as KullaniciListViewModel).OnRefresh();
        }
    }
}
