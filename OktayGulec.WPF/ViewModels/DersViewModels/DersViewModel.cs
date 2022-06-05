using OktayGulec.DatabaseAccessLayer;
using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.WPF.ViewModels.DersViewModels
{
    public class DersViewModel : ViewModelBase
    {
        private Ders _ders;
        public Ders Ders { get => _ders; }

        public int Id 
        { 
            get => Ders.Id; 
            set
            {
                if(Ders.Id != value)
                {
                    Ders.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad 
        {
            get => Ders.Ad;
            set
            {
                if(Ders.Ad != value)
                {
                    Ders.Ad = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Vize 
        {
            get => Ders.Vize;
            set
            {
                if (Ders.Vize != value)
                {
                    Ders.Vize = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Ortalama");
                }
            }
        }
        public double Final
        {
            get => Ders.Final;
            set
            {
                if (Ders.Final != value)
                {
                    Ders.Final = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Ortalama");
                }
            }
        }

        public double Ortalama 
        {
            get => Ders.Ortalama;
        }

        private Hoca _selectedHoca;
        public Hoca SelectedHoca 
        {
            get => _selectedHoca;
            set
            {
                if (_selectedHoca != value)
                {
                    _selectedHoca = value;
                    Ders.HocaId = _selectedHoca.Id;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Hoca> Hocalar { get; set; }

        public async Task GetHocalar()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Hocalar = new ObservableCollection<Hoca>(await uow.HocaRepository.GetItems());
            }
        }

        public DersViewModel() : this(new Ders()) { }

        public DersViewModel(Ders ders)
        {
            this._ders = ders;
        }
    }
}
