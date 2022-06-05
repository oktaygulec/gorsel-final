using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.WPF.ViewModels.KullaniciViewModels
{
    public class KullaniciViewModel : ViewModelBase
    {
        private Kullanici _kullanici;
        public Kullanici Kullanici { get => _kullanici; }

        public int Id 
        { 
            get => Kullanici.Id; 
            set
            {
                if (Kullanici.Id != value)
                {
                    Kullanici.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EPosta 
        { 
            get => Kullanici.EPosta; 
            set
            {
                if(Kullanici.EPosta != value)
                {
                    Kullanici.EPosta = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Parola
        {
            get => Kullanici.Parola;
            set
            {
                if (Kullanici.Parola != value)
                {
                    Kullanici.Parola = value;
                    OnPropertyChanged();
                }
            }
        }

        public KullaniciViewModel() : this(new Kullanici()) { }
        public KullaniciViewModel(Kullanici kullanici)
        {
            this._kullanici = kullanici;
        }
    }
}
