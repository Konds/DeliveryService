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
    /// MongoDbContextPoint
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.IDatabaseContext{CommonCore.Interfaces.IPoint}" />
    public class MongoDbContextPoint : IDatabaseContext<IPoint>
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
        private const string _collection = "Points";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbContextPoint"/> class.
        /// </summary>
        public MongoDbContextPoint()
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
        public async Task<IEnumerable<IPoint>> GetAllAsync()
        {
            return await _database.GetCollection<IPoint>("_collection")
                                                        .Find(_ => true)
                                                        .ToListAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IPoint> GetAsync(string id)
        {
            FilterDefinition<IPoint> filter = Builders<IPoint>.Filter.Eq(p => p.ObjectId, id);

            return await _database.GetCollection<IPoint>("_collection").Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public async Task AddAsync(IPoint p)
        {
            await _database.GetCollection<IPoint>("_collection").InsertOneAsync(p);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string id, IPoint p)
        {
            ReplaceOneResult updateResult =
           await _database.GetCollection<IPoint>("_collection")
                   .ReplaceOneAsync(
                       filter: g => g.ObjectId == p.ObjectId,
                       replacement: p);

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
            FilterDefinition<IPoint> filter = Builders<IPoint>.Filter.Eq(p => p.ObjectId, id);

            DeleteResult deleteResult = await _database.GetCollection<IPoint>("_collection").DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        #endregion

        #region Sync Operations

        public IEnumerable<IPoint> GetAll()
        {
            return _database.GetCollection<IPoint>("_collection").Find(_ => true).ToList();
        }

        public IPoint Get(string id)
        {
            FilterDefinition<IPoint> filter = Builders<IPoint>.Filter.Eq(p => p.ObjectId, id);

            return _database.GetCollection<IPoint>("_collection").Find(filter).FirstOrDefault();
        }

        public void Add(IPoint p)
        {
            _database.GetCollection<IPoint>("_collection").InsertOneAsync(p);
        }

        public bool Update(string id, IPoint p)
        {
            ReplaceOneResult updateResult =
              _database.GetCollection<IPoint>("_collection")
                    .ReplaceOne(
                        filter: g => g.ObjectId == p.ObjectId,
                        replacement: p);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public bool Remove(string id)
        {
            FilterDefinition<IPoint> filter = Builders<IPoint>.Filter.Eq(p => p.ObjectId, id);

            DeleteResult deleteResult = _database.GetCollection<IPoint>("_collection").DeleteOne(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        #endregion
    }
}
