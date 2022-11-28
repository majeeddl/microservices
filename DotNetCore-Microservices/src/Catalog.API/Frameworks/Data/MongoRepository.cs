using Catalog.API.Domains.Interfaces;
using MongoDB.Driver;

namespace Catalog.API.Frameworks.Data
{

    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _dbCollection;

        private readonly FilterDefinitionBuilder<T> _filterDefinitionBuilder = Builders<T>.Filter;


        public MongoRepository(IMongoDatabase database)
        {

            var collectionName = typeof(T).Name.ToLowerInvariant() + "s";

            _dbCollection = database.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await this._dbCollection.Find(_filterDefinitionBuilder.Empty).ToListAsync();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
