using ChattyDAL.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Data
{
    public class DataAccesserCosmos<T> : IDataAccesserAsync<T> where T: class
    {
        private readonly Container _container;

        public DataAccesserCosmos(Container container)
        {
            _container = container;
        }

        public async Task<T> AddItem(T item)
        {
            var responceItem = await _container.CreateItemAsync(item);

            return responceItem;
        }

        public Task<T> DeleteItem(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetItem(Expression<Func<T, bool>> predicate)
        {
            var responce = await _container.GetItemLinqQueryable<T>(true).Where(predicate).ToFeedIterator().ReadNextAsync();

            return responce.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate)
        {
            var responce = await _container.GetItemLinqQueryable<T>(true).Where(predicate).ToFeedIterator().ReadNextAsync();
            
            return responce;
        }

        public async Task<T> UpdateItem(T item)
        {
            return await _container.UpsertItemAsync<T>(item);
        }
    }
}
