using OktayGulec.DatabaseAccessLayer.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.DatabaseAccessLayer.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task<T> GetItem(int? id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetItems()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<int> Add(T item)
        {
            Context.Set<T>().Add(item);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(T item)
        {
            if(Context.Entry<T>(item).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(item);
            }
            Context.Entry<T>(item).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            if (Context.Entry<T>(item).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(item);
            }
            Context.Entry<T>(item).State = EntityState.Deleted;
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
