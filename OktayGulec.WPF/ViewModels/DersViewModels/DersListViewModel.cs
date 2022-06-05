using OktayGulec.DatabaseAccessLayer;
using OktayGulec.WPF.Utils;
using OktayGulec.WPF.Views.DersViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OktayGulec.WPF.ViewModels.DersViewModels
{
    public class DersListViewModel : ViewModelBase
    {
        private ObservableCollection<DersViewModel> _items;
        public ObservableCollection<DersViewModel> Items { get => _items; set => SetProperty(ref _items, value); }

        private DersViewModel _selectedItem;
        public DersViewModel SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public DersListViewModel()
        {
            RefreshCommand = new RelayCommand(async _ => await OnRefresh());
            InsertCommand = new RelayCommand(async _ => await OnInsert());
            UpdateCommand = new RelayCommand(async o => await OnUpdate(o));
            DeleteCommand = new RelayCommand(async o => await OnDelete(o));
        }

        public async Task OnRefresh()
        {
            Items = new ObservableCollection<DersViewModel>();

            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var item in await uow.DersRepository.GetItemsWithHoca())
                {
                    Items.Add(new DersViewModel 
                    { 
                        Id = item.Id, 
                        Ad = item.Ad, 
                        Vize = item.Vize, 
                        Final = item.Final,
                        SelectedHoca = item.Hoca
                    });
                }
            }
        }

        private async Task OnInsert()
        {
            var dvm = new DersViewModel();
            await dvm.GetHocalar();
            DersView dv = new DersView(dvm);
            dv.Title = "Ders Ekle";
            if (dv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.DersRepository.Add(dvm.Ders) > 0)
                        Items.Add(dvm);
                    else
                        MessageBox.Show("Ders ekleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task OnUpdate(object item)
        {
            if(item == null)
            {
                MessageBox.Show("Ders seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DersViewModel dvm = item as DersViewModel;
            await dvm.GetHocalar();
            DersView dv = new DersView(dvm);
            dv.Title = "Ders Güncelle";

            if (dv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.DersRepository.Update(dvm.Ders) == 0)
                        MessageBox.Show("Ders güncelleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task OnDelete(object item)
        {
            if (item == null)
            {
                MessageBox.Show("Ders seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DersViewModel dvm = item as DersViewModel;
            if (MessageBox.Show(dvm.Ad + " adlı dersi silmek istiyor musunuz?", "Ders Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.DersRepository.Delete(dvm.Ders) > 0)
                        Items.Remove(dvm);
                    else
                        MessageBox.Show("Ders silme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
