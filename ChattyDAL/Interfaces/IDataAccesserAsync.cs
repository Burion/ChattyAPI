using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IDataAccesserAsync<T>
    {
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task<T> DeleteItem(T item);
        Task<T> GetItem(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate);
    }
}
