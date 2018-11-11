/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using BusinessObjects;
using CommonCore.Interfaces;
using CommonCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder.Tests.MockRepositories
{
    /// <summary>
    /// Mock Repository for points.
    /// </summary>
    /// <seealso cref="CommonCore.Repositories.IPointRepository{CommonCore.Interfaces.IPoint}" />
    public class MockPointRepository : IPointRepository<IPoint>
    {
        /// <summary>
        /// The mock collection
        /// </summary>
        private IList<IPoint> MockCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockPointRepository"/> class.
        /// </summary>
        public MockPointRepository()
        {
            InitializeData();
        }

        /// <summary>
        /// Adds the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        public void Add(IPoint p)
        {
            MockCollection.Add(p);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task <IPointRepository<IPoint>> AddAsync(IPoint p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IPoint Get(string id)
        {
           return MockCollection.FirstOrDefault(p => p.ObjectId.Equals(id));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPoint> GetAll()
        {
            return MockCollection;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<IPoint>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IPoint> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool Remove(string id)
        {
            IPoint point = MockCollection.FirstOrDefault(p => p.ObjectId.Equals(id));
            return MockCollection.Remove(point);
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public bool Update(string id, IPoint p)
        {
            IPoint point = MockCollection.FirstOrDefault(i => i.ObjectId.Equals(id));
            MockCollection.Remove(point);
            MockCollection.Add(p);

            return true;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(string id, IPoint p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IPointRepository<IPoint>.AddAsync(IPoint p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        private void InitializeData()
        {
            MockCollection = new List<IPoint>()
            {
               new Point(){ Name= "A", ObjectId = Guid.NewGuid().ToString() },
               new Point(){ Name= "B", ObjectId = Guid.NewGuid().ToString() },
               new Point(){ Name= "C", ObjectId = Guid.NewGuid().ToString() },
               new Point(){ Name= "D", ObjectId = Guid.NewGuid().ToString() },
               new Point(){ Name= "E", ObjectId = Guid.NewGuid().ToString() }
            };
        }

    }
}
