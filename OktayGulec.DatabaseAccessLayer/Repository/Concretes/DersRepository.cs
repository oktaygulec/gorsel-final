using OktayGulec.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.DatabaseAccessLayer.Repository.Concretes
{
    public class DersRepository : Repository<Ders>
    {
        public DersRepository(DbContext context) : base(context) {}

        public async Task<Ders> GetItemWithHoca(int? id)
        {
            return await Context.Set<Ders>().Include(x => x.Hoca).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Ders>> GetItemsWithHoca()
        {
            return await Context.Set<Ders>().Include(x => x.Hoca).ToListAsync();
        }
    }
}
