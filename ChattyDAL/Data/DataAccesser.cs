using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Data
{
    public class DataAccesser<T> where T: class
    {
        readonly ChattyContext _context;
        public DataAccesser() 
        {
            _context = new ChattyContext();
        }

        public T AddItem(T item)
        {
            var itemToReturn = _context.Set<T>().Add(item);
            _context.SaveChanges();

            return item;
        }

        public T UpdateItem(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();

            return item;
        }

        public T DeleteItem(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();

            return item;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
