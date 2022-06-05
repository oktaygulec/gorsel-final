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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OktayGulec.WPF.Views.HocaViews
{
    /// <summary>
    /// Interaction logic for HocaListView.xaml
    /// </summary>
    public partial class HocaListView : Page
    {
        public HocaListView()
        {
            InitializeComponent();
            DataContext = new HocaListViewModel();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await(DataContext as HocaListViewModel).OnRefresh();
        }
    }
}
