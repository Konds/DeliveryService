/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace DataAccess.DatabaseContexts
{
    /// <summary>
    /// MongoDbContextRoute
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.IDatabaseContext{CommonCore.Interfaces.IRoute}" />
    public class MongoDbContextRoute : IDatabaseContext<IRoute>
    {
        #region Private Variables

        /// <summary>
        /// The client
        /// </summary>
        private IMongoClient _client;
        /// <summary>
        /// The database
        /// </summary>
        private IMongoDatabase _database;

        /// <summary>
        /// The connectionstring setting
        /// </summary>
        private const string _connectionstringSetting = "MongoDBConectionString";
        /// <summary>
        /// The database name setting
        /// </summary>
        private const string _databaseNameSetting = "MongoDBDatabaseName";
        /// <summary>
        /// The collection
        /// </summary>
        private const string _collection = "Routes";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbContextRoute"/> class.
        /// </summary>
        public MongoDbContextRoute()
        {
            var _connectionString = MongoUrl.Create(ConfigurationManager.AppSettings[_connectionstringSetting]);
            _client = new MongoClient(_connectionString);

            _database = _client.GetDatabase(ConfigurationManager.AppSettings[_databaseNameSetting]);
        }

        #endregion

        #region Async Operations

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IRoute>> GetAllAsync()
        {
            return await _database.GetCollection<IRoute>(_collection)
                                                        .Find(_ => true)
                                                        .ToListAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IRoute> GetAsync(string id)
        {
            FilterDefinition<IRoute> filter = Builders<IRoute>.Filter.Eq(p => p.ObjectId, id);

            return await _database.GetCollection<IRoute>(_collection).Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public async Task AddAsync(IRoute r)
        {
            await _database.GetCollection<IRoute>(_collection).InsertOneAsync(r);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string id, IRoute r)
        {
            ReplaceOneResult updateResult =
           await _database.GetCollection<IRoute>(_collection)
                   .ReplaceOneAsync(
                       filter: g => g.ObjectId == r.ObjectId,
                       replacement: r);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;

        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string id)
        {
            FilterDefinition<IRoute> filter = Builders<IRoute>.Filter.Eq(p => p.ObjectId, id);

            DeleteResult deleteResult = await _database.GetCollection<IRoute>(_collection).DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        #endregion

        #region Sync Operations

        public IEnumerable<IRoute> GetAll()
        {
            return _database.GetCollection<IRoute>(_collection).Find(_ => true).ToList();
        }

        public IRoute Get(string id)
        {
            FilterDefinition<IRoute> filter = Builders<IRoute>.Filter.Eq(p => p.ObjectId, id);

            return _database.GetCollection<IRoute>(_collection).Find(filter).FirstOrDefault();
        }

        public void Add(IRoute r)
        {
            _database.GetCollection<IRoute>(_collection).InsertOneAsync(r);
        }

        public bool Update(string id, IRoute r)
        {
            ReplaceOneResult updateResult =
              _database.GetCollection<IRoute>(_collection)
                    .ReplaceOne(
                        filter: g => g.ObjectId == r.ObjectId,
                        replacement: r);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public bool Remove(string id)
        {
            FilterDefinition<IRoute> filter = Builders<IRoute>.Filter.Eq(p => p.ObjectId, id);

            DeleteResult deleteResult = _database.GetCollection<IRoute>(_collection).DeleteOne(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        #endregion
    }
}
