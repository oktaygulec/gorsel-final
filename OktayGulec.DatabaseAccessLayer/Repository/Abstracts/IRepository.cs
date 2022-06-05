using OktayGulec.DatabaseAccessLayer.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OktayGulec.DatabaseAccessLayer.Repository.Abstracts
{
    public interface IRepository<T> : IDisposable
    {
        Task<T> GetItem(int? id);
        Task<List<T>> GetItems();
        Task<int> Add(T item);
        Task<int> Update(T item);
        Task<int> Delete(T item);
    }
}
