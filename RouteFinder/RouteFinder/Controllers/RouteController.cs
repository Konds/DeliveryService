/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using CommonCore.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Unity.Attributes;

namespace RouteFinder.Controllers
{
    /// <summary>
    /// Controller for the System Resource 'Route'
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/v1/deliveryservice/routes")]
    public class RouteController : ApiController
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        [Dependency]
        IRouteRepository<IRoute> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteController"/> class.
        /// </summary>
        public RouteController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        public RouteController(IRouteRepository<IRoute> repo)
        {
            Repository = repo;
        }

        #region Async Operations

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await Repository.GetAllAsync());
        }

        /// <summary>
        /// Finds the shortest route.
        /// </summary>
        /// <param name="cost">The cost.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> FindShortestRoute([FromBody]ICostValue cost, IPoint start, IPoint end)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            var point = await Repository.GetAsync(id);

            if (point == null)
                return NotFound();

            return Ok(point);
        }

        /// <summary>
        /// Posts the specified route.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]IRoute route)
        {
            await Repository.AddAsync(route);

            return Ok(route);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="route">The route.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrators")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(string id, [FromBody]IRoute route)
        {
            var pointFromDb = await Repository.GetAsync(id);
            if (pointFromDb == null)
                return NotFound();

            route.ObjectId = pointFromDb.ObjectId;
            await Repository.UpdateAsync(id, route);

            return Ok(route);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrators")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var pointsFromDb = await Repository.GetAsync(id);
            if (pointsFromDb == null)
                return NotFound();

            await Repository.RemoveAsync(id);
            return Ok();
        }

        #endregion
    }
}
