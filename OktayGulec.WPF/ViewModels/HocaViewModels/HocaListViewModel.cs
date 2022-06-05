using OktayGulec.DatabaseAccessLayer;
using OktayGulec.WPF.Utils;
using OktayGulec.WPF.Views.HocaViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OktayGulec.WPF.ViewModels.HocaViewModels
{
    public class HocaListViewModel : ViewModelBase
    {
        private ObservableCollection<HocaViewModel> _items;
        public ObservableCollection<HocaViewModel> Items { get => _items; set => SetProperty(ref _items, value); }

        private HocaViewModel _selectedItem;
        public HocaViewModel SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public HocaListViewModel()
        {
            RefreshCommand = new RelayCommand(async _ => await OnRefresh());
            InsertCommand = new RelayCommand(async _ => await OnInsert());
            UpdateCommand = new RelayCommand(async o => await OnUpdate(o));
            DeleteCommand = new RelayCommand(async o => await OnDelete(o));
        }

        public async Task OnRefresh()
        {
            Items = new ObservableCollection<HocaViewModel>();

            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var item in await uow.HocaRepository.GetItems())
                {
                    Items.Add(new HocaViewModel { Id = item.Id, Ad = item.Ad, Soyad = item.Soyad });
                }
            }
        }

        private async Task OnInsert()
        {
            HocaView hv = new HocaView(new HocaViewModel());
            hv.Title = "Hoca Ekle";
            if (hv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var hvm = hv.DataContext as HocaViewModel;
                    if(await uow.HocaRepository.Add(hvm.Hoca) > 0)
                        Items.Add(hvm);
                    else
                        MessageBox.Show("Hoca ekleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task OnUpdate(object item)
        {
            if (item == null)
            {
                MessageBox.Show("Hoca seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            HocaViewModel hvm = item as HocaViewModel;
            HocaView hv = new HocaView(hvm);
            hv.Title = "Hoca Güncelle";

            if (hv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.HocaRepository.Update(hvm.Hoca) == 0)
                        MessageBox.Show("Hoca güncelleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task OnDelete(object item)
        {
            if (item == null)
            {
                MessageBox.Show("Hoca seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            HocaViewModel hvm = item as HocaViewModel;
            if (MessageBox.Show(hvm.Hoca.AdSoyad + " adlı hocayı silmek istiyor musunuz?", "Hoca Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.HocaRepository.Delete(hvm.Hoca) > 0)
                        Items.Remove(hvm);
                    else
                        MessageBox.Show("Hoca silme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
