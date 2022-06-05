using OktayGulec.DatabaseAccessLayer;
using OktayGulec.EntityLayer.Models;
using OktayGulec.WPF.Utils;
using OktayGulec.WPF.Views.KullaniciViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OktayGulec.WPF.ViewModels.KullaniciViewModels
{
    public class KullaniciListViewModel : ViewModelBase
    {
        private ObservableCollection<KullaniciViewModel> _items;
        public ObservableCollection<KullaniciViewModel> Items { get => _items; set => SetProperty(ref _items, value); }

        private KullaniciViewModel _selectedItem;
        public KullaniciViewModel SelectedItem { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public KullaniciListViewModel()
        {
            RefreshCommand = new RelayCommand(async _ => await OnRefresh());
            InsertCommand = new RelayCommand(async _ => await OnInsert());
            UpdateCommand = new RelayCommand(async o => await OnUpdate(o));
            DeleteCommand = new RelayCommand(async o => await OnDelete(o));
        }

        public async Task OnRefresh()
        {
            Items = new ObservableCollection<KullaniciViewModel>();

            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var item in await uow.KullaniciRepository.GetItems())
                {
                    Items.Add(new KullaniciViewModel { Id = item.Id, EPosta = item.EPosta, Parola = item.Parola });
                }
            }
        }
        
        private async Task OnInsert()
        {
            KullaniciView kv = new KullaniciView(new KullaniciViewModel());
            kv.Title = "Kullanıcı Ekle";
            if (kv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var kvm = kv.DataContext as KullaniciViewModel;
                    try
                    {
                        if(await uow.KullaniciRepository.Add(kvm.Kullanici) > 0)
                            Items.Add(kvm);
                        else
                            MessageBox.Show("Kullanıcı ekleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private async Task OnUpdate(object item)
        {
            if (item == null)
            {
                MessageBox.Show("Kullanıcı seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            KullaniciViewModel kvm = item as KullaniciViewModel;
            var eskiEPosta = kvm.EPosta;
            var eskiParola = kvm.Parola;
            KullaniciView kv = new KullaniciView(kvm);
            kv.Title = "Kullanıcı Güncelle";

            if (kv.ShowDialog() == true)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    try
                    {
                        if (await uow.KullaniciRepository.Update(eskiEPosta, kvm.Kullanici) == 0)
                            MessageBox.Show("Kullanıcı güncelleme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        kvm.EPosta = eskiEPosta;
                        kvm.Parola = eskiParola;
                    }
                }
            }
        }

        private async Task OnDelete(object item)
        {
            if (item == null)
            {
                MessageBox.Show("Kullanıcı seçiniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            KullaniciViewModel kvm = item as KullaniciViewModel;
            if (MessageBox.Show(kvm.EPosta + " E-Postalı kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (await uow.KullaniciRepository.Delete(kvm.Kullanici) > 0)
                        Items.Remove(kvm);
                    else
                        MessageBox.Show("Kullanıcı silme başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
