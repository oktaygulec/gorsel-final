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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OktayGulec.WPF.Views.DersViews
{
    /// <summary>
    /// Interaction logic for DersListView.xaml
    /// </summary>
    public partial class DersListView : Page
    {
        public DersListView()
        {
            InitializeComponent();
            DataContext = new DersListViewModel();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await(DataContext as DersListViewModel).OnRefresh();

        }
    }
}
