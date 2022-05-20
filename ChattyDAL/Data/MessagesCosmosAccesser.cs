using ChattyDAL.Interfaces;
using ChattyDAL.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Data
{
    public class MessagesCosmosAccesser : IMessagesAccesser
    {
        private readonly DataAccesserCosmos<Message> _dataAccesser;
        
        public MessagesCosmosAccesser(CosmosClient client, IConfiguration configuration)
        {
            var databaseName = configuration.GetValue<string>("CosmosDbName");
            var database = client.GetDatabase(databaseName);

            if (database == null)
                throw new KeyNotFoundException($"Couldn't find database called {databaseName}");

            var collectionName = configuration.GetValue<string>("MessagesCosmosCollectionName");
            var collection = database.GetContainer(collectionName);

            if (collection == null)
                throw new KeyNotFoundException($"No collection found in database {databaseName} with name {collectionName}");

            _dataAccesser = new DataAccesserCosmos<Message>(collection);
        }

        public Task<Message> GetMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Message>> GetMessages(Expression<Func<Message, bool>> predicate)
        {
            var items = await _dataAccesser.GetItems(predicate);

            return items;
        }

        public async Task<Message> UpsertMessage(Message message)
        {
            var item = await _dataAccesser.AddItem(message);

            return item;
        }
    }
}
