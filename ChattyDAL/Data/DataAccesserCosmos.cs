using ChattyDAL.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Data
{
    public class DataAccesserCosmos<T> : IDataAccesser<T> where T: class
    {
        private readonly CosmosClient _client;

        public DataAccesserCosmos(CosmosClient client)
        {
            _client = client;
        }

        public T AddItem(T item)
        {
            throw new NotImplementedException();
        }

        public T DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
