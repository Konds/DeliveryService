/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using BusinessObjects;
using BusinessObjects.BusinessModel;
using CommonCore.Interfaces;
using CommonCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder.Tests.MockRepositories
{
    /// <summary>
    /// Mock Repository for routes.
    /// </summary>
    /// <seealso cref="CommonCore.Repositories.IRouteRepository{CommonCore.Interfaces.IRoute}" />
    public class MockRouteRepository : IRouteRepository<IRoute>
    {
        /// <summary>
        /// The mock collection
        /// </summary>
        private IList<IRoute> MockCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockRouteRepository"/> class.
        /// </summary>
        public MockRouteRepository()
        {
            InitializeData();
        }

        /// <summary>
        /// Adds the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        public void Add(IRoute p)
        {
            MockCollection.Add(p);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task AddAsync(IRoute p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IRoute Get(string id)
        {
            return MockCollection.FirstOrDefault(p => p.ObjectId.Equals(id));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRoute> GetAll()
        {
            return MockCollection;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<IRoute>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IRoute> GetAsync(string id)
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
            IRoute route = MockCollection.FirstOrDefault(p => p.ObjectId.Equals(id));
            return MockCollection.Remove(route);
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
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public bool Update(string id, IRoute r)
        {
            IRoute route = MockCollection.FirstOrDefault(p => p.ObjectId.Equals(id));
            MockCollection.Remove(route);
            MockCollection.Add(r);

            return true;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateAsync(string id, IRoute p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        private void InitializeData()
        {
            MockCollection = new List<IRoute>()
            {
               new Route() {
                   ObjectId = Guid.NewGuid().ToString(),
                   EndPoint = new Point(){ Name= "B", ObjectId = Guid.NewGuid().ToString() },
                   StartPoint = new Point(){ Name= "A", ObjectId = Guid.NewGuid().ToString() },
                   RouteCost = new RouteCost
                   {
                        Cost = new CostValue
                        {
                            Value = 89
                        },
                        TimeCost = new TimeCostValue
                        {
                            Value = 99
                        }
                   }
               },
               new Route() {
                   ObjectId = Guid.NewGuid().ToString(),
                   EndPoint = new Point(){ Name= "B", ObjectId = Guid.NewGuid().ToString() },
                   StartPoint = new Point(){ Name= "C", ObjectId = Guid.NewGuid().ToString() },
                   RouteCost = new RouteCost
                   {
                        Cost = new CostValue
                        {
                            Value = 2
                        },
                        TimeCost = new TimeCostValue
                        {
                            Value = 45
                        }
                   }
               }
            };
        }
    }
}
