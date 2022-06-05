using OktayGulec.DatabaseAccessLayer.DatabaseContext;
using OktayGulec.DatabaseAccessLayer.Repository.Concretes;
using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.DatabaseAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private DBContext context = new DBContext();

        private Repository<Hoca> _hocaRepository;
        public Repository<Hoca> HocaRepository 
        {
            get
            {
                if (_hocaRepository == null)
                    _hocaRepository = new Repository<Hoca>(context);
                return _hocaRepository;
            }
        }

        private KullaniciRepository _kullaniciRepository;
        public KullaniciRepository KullaniciRepository 
        {
            get
            {
                if (_kullaniciRepository == null)
                    _kullaniciRepository = new KullaniciRepository(context);
                return _kullaniciRepository;
            }
        }

        private DersRepository _dersRepository;
        public DersRepository DersRepository
        {
            get
            {
                if (_dersRepository == null)
                    _dersRepository = new DersRepository(context);
                return _dersRepository;
            }
        }

        public void Dispose()
        {
            context?.Dispose();
            _hocaRepository?.Dispose();
            _kullaniciRepository?.Dispose();
            _dersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
