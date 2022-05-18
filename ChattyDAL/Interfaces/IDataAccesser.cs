using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IDataAccesser<T>
    {
        T AddItem(T item);
        T UpdateItem(T item);
        T DeleteItem(T item);
        T GetItem(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate);
    }
}
