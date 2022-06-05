using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.DatabaseAccessLayer.Repository.Concretes
{
    public class KullaniciRepository : Repository<Kullanici>
    {
        public KullaniciRepository(DbContext context) : base(context) {}

        public async Task<Kullanici> GetItem(string eposta)
        {
            return await Context.Set<Kullanici>().FirstOrDefaultAsync(x => x.EPosta == eposta);
        } 

        public async Task<bool> Login(string eposta, string parola)
        {
            var kullanici = await Context.Set<Kullanici>().FirstOrDefaultAsync(x => x.EPosta == eposta && x.Parola == parola);

            return kullanici != null ? true : false;
        }

        public new async Task<int> Add(Kullanici item)
        {
            var kullanici = await GetItem(item.EPosta);

            if (kullanici != null)
                throw new Exception("Kullanıcı zaten mevcut.");

            var k = Context.Set<Kullanici>().Add(item);
            item.Id = k.Id;
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(string eskiEPosta, Kullanici item)
        {
            var kullaniciVarMi = await GetItem(item.EPosta);

            if (kullaniciVarMi != null && kullaniciVarMi.EPosta != eskiEPosta)
                throw new Exception("Kullanıcı zaten mevcut.");

            var kullanici = await GetItem(eskiEPosta);
            if (kullanici != null)
            {
                kullanici.EPosta = item.EPosta;
                kullanici.Parola = item.Parola;
            }
            return await Context.SaveChangesAsync();
        }
    }
}
