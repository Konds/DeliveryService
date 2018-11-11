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
using DataAccess.DatabaseContexts;
using Repositories.DataLayer;
using RouteFinder.Common;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace RouteFinder
{
    /// <summary>
    /// Application Config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            #region Container Registration

            config.DependencyResolver = new UnityResolver(UnityConfig.Container);

            #endregion Container Registration

            #region Routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion Routes

            #region Filters

            // config.Filters.Add(new AuthorizeAttribute());

            #endregion Filters
        }
    }
}
