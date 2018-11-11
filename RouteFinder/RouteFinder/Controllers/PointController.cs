/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using BusinessObjects;
using CommonCore.Interfaces;
using CommonCore.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using Unity.Attributes;

namespace RouteFinder.Controllers
{
    /// <summary>
    /// Controller for the System Resource 'Point'
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [Route("api/v1/deliveryservice/points")]
    public class PointController : ApiController
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        [Dependency]
        IPointRepository<IPoint> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointController"/> class.
        /// </summary>
        public PointController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        public PointController(IPointRepository<IPoint> repo)
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
        /// Posts the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]IPoint point)
        {
            await Repository.AddAsync(point);

            return Ok(point);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrators")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(string id, [FromBody]IPoint point)
        {
            var pointFromDb = await Repository.GetAsync(id);
            if (pointFromDb == null)
                return NotFound();

            point.ObjectId = pointFromDb.ObjectId;
            await Repository.UpdateAsync(id, point);

            return Ok(point);
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
