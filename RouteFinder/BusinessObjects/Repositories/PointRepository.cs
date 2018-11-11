/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using CommonCore.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Attributes;

namespace Repositories.DataLayer
{
    /// <summary>
    /// Point Repository
    /// </summary>
    /// <seealso cref="CommonCore.Repositories.IPointRepository{CommonCore.Interfaces.IPoint}" />
    public sealed class PointRepository : IPointRepository<IPoint>
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        [Dependency]
        public IDatabaseContext<IPoint> DatabaseContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointRepository"/> class.
        /// </summary>
        public PointRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointRepository"/> class.
        /// </summary>
        /// <param name="dataBaseContext">The data base context.</param>
        public PointRepository(IDatabaseContext<IPoint> dataBaseContext)
        {
            DatabaseContext = dataBaseContext;
        }

        #region Async Operations

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IPoint>> GetAllAsync()
        {
            return await DatabaseContext.GetAllAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IPoint> GetAsync(string id)
        {
            return await DatabaseContext.GetAsync(id);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public async Task AddAsync(IPoint p)
        {
            await DatabaseContext.AddAsync(p);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string id, IPoint p)
        {
            return await DatabaseContext.UpdateAsync(id, p);

        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string id)
        {
            return await DatabaseContext.RemoveAsync(id);
        }

        #endregion

        #region Sync Operations

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPoint> GetAll()
        {
            return DatabaseContext.GetAll();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IPoint Get(string id)
        {
            FilterDefinition<IPoint> filter = Builders<IPoint>.Filter.Eq(p => p.ObjectId, id);

            return DatabaseContext.Get(id);
        }

        /// <summary>
        /// Adds the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        public void Add(IPoint p)
        {
            DatabaseContext.Add(p);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public bool Update(string id, IPoint p)
        {
            return DatabaseContext.Update(id, p);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Remove(string id)
        {
            return DatabaseContext.Remove(id);
        }

        #endregion

        }
}
