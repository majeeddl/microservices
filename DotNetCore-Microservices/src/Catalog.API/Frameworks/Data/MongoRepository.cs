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

        public async Task<T> GetAsync(string id)
        {
            var filter = _filterDefinitionBuilder.Eq(e => e.Id,id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async  Task<T> CreateAsync(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _dbCollection.ReplaceOneAsync(filter: e => e.Id == entity.Id,replacement: entity);

            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _dbCollection.DeleteOneAsync(filter: e => e.Id == id);
        }
    }
}
