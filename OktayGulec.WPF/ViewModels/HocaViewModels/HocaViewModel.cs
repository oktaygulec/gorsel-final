using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.WPF.ViewModels.HocaViewModels
{
    public class HocaViewModel : ViewModelBase
    {
        private Hoca _hoca;
        public Hoca Hoca { get => _hoca; }

        public int Id 
        { 
            get => Hoca.Id; 
            set
            {
                if (Hoca.Id != value)
                {
                    Hoca.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad 
        {
            get => Hoca.Ad; 
            set
            {
                if (Hoca.Ad != value)
                {
                    Hoca.Ad = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Soyad 
        {
            get => Hoca.Soyad;
            set
            {
                if (Hoca.Soyad != value)
                {
                    Hoca.Soyad = value;
                    OnPropertyChanged();
                }
            }
        }

        public HocaViewModel() : this(new Hoca()) {}

        public HocaViewModel(Hoca hoca)
        {
            this._hoca = hoca;
        }
    }
}
