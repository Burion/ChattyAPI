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
    public class UsersCosmosAccesser : IUsersAccesser
    {
        private DataAccesserCosmos<Models.User> _dataAccesser;

        public UsersCosmosAccesser(CosmosClient client, IConfiguration configuration)
        {
            var databaseName = configuration.GetValue<string>("CosmosDbName");
            var database = client.GetDatabase(databaseName);

            if (database == null)
                throw new KeyNotFoundException($"Couldn't find database called {databaseName}");

            var collectionName = configuration.GetValue<string>("UsersCosmosCollectionName");
            var collection = database.GetContainer(collectionName);

            if (collection == null)
                throw new KeyNotFoundException($"No collection found in database {databaseName} with name {collectionName}");

            _dataAccesser = new DataAccesserCosmos<Models.User>(collection);
        }

        public async Task<Models.User> GetUser(Expression<Func<Models.User, bool>> predicate)
        {
            return await _dataAccesser.GetItem(predicate);
        }

        public async Task<IEnumerable<Models.User>> GetUsers(Expression<Func<Models.User, bool>> predicate)
        {
            return await _dataAccesser.GetItems(predicate);
        }

        public async Task<Models.User> InsertUser(Models.User user)
        {
            user.Id = Guid.NewGuid().ToString();

            return await _dataAccesser.AddItem(user);
        }

        public async Task<Models.User> UpdateUser(Models.User user)
        {
            return await _dataAccesser.UpdateItem(user);
        }
    }
}
