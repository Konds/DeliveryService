/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore.Interfaces
{
    /// <summary>
    /// IDatabaseContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDatabaseContext<T>
    {
        #region Async Operations

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetAsync(string id);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        Task AddAsync(T p);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(string id, T p);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string id);

        #endregion

        #region Sync Operations

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(string id);

        /// <summary>
        /// Adds the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        void Add(T p);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        bool Update(string id, T p);

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool Remove(string id);

        #endregion
    }
}
