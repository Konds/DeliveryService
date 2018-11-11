/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using CommonCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Attributes;

namespace Repositories.DataLayer
{
    /// <summary>
    /// RouteRepository
    /// </summary>
    /// <seealso cref="CommonCore.Repositories.IRouteRepository{CommonCore.Interfaces.IRoute}" />
    public class RouteRepository : IRouteRepository<IRoute>
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        [Dependency]
        public IDatabaseContext<IRoute> DatabaseContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteRepository"/> class.
        /// </summary>
        public RouteRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteRepository"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        public RouteRepository(IDatabaseContext<IRoute> databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        #region Async Operations

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IRoute>> GetAllAsync()
        {
            return await DatabaseContext.GetAllAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IRoute> GetAsync(string id)
        {
            return await DatabaseContext.GetAsync(id);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public async Task AddAsync(IRoute r)
        {
            await DatabaseContext.AddAsync(r);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string id, IRoute r)
        {
            return await DatabaseContext.UpdateAsync(id, r);

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
        public IEnumerable<IRoute> GetAll()
        {
            return DatabaseContext.GetAll();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IRoute Get(string id)
        {
            return DatabaseContext.Get(id);
        }

        /// <summary>
        /// Adds the specified r.
        /// </summary>
        /// <param name="r">The r.</param>
        public void Add(IRoute r)
        {
            DatabaseContext.Add(r);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public bool Update(string id, IRoute r)
        {
            return DatabaseContext.Update(id, r);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Remove(string id)
        {
            return Remove(id);
        }

        #endregion
    }
}
