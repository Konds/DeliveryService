/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using CommonCore.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteFinder.Controllers;
using RouteFinder.Tests.MockRepositories;

namespace RouteFinder.Tests.UnitTests
{
    /// <summary>
    /// Set of basic tests.
    /// </summary>
    [TestClass]
    public class ControllerUnitTest
    {
        /// <summary>
        /// Tests the point controlller crud.
        /// </summary>
        [TestMethod]
        public void TestPointControlllerCRUD()
        {
            IPointRepository<IPoint> mock = new MockPointRepository();

            var controller = new PointController(mock);
        }

        /// <summary>
        /// Tests the route controlller crud.
        /// </summary>
        [TestMethod]
        public void TestRouteControlllerCRUD()
        {
            IRouteRepository<IRoute> mock = new MockRouteRepository();

            var controller = new RouteController(mock);
        }
    }
}
