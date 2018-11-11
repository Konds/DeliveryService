using BusinessObjects;
using BusinessObjects.BusinessModel;
using CommonCore.Interfaces;
using CommonCore.Repositories;
using DataAccess.DatabaseContexts;
using Repositories.DataLayer;
using System;
using Unity;
using Unity.Lifetime;

namespace RouteFinder
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // Basic Model
            container.RegisterType<IPoint, Point>();
            container.RegisterType<IRoute, Route>();
            container.RegisterType<ITimeCostValue, TimeCostValue>();
            container.RegisterType<ICostValue, CostValue>();
            container.RegisterType<IRouteCost, RouteCost>();

            // Database Contexts
            container.RegisterType<IDatabaseContext<IPoint>, MongoDbContextPoint>(new HierarchicalLifetimeManager());
            container.RegisterType<IDatabaseContext<IRoute>, MongoDbContextRoute>(new HierarchicalLifetimeManager());

            // Repositories
            container.RegisterType<IPointRepository<IPoint>, PointRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRouteRepository<IRoute>, RouteRepository>(new HierarchicalLifetimeManager());
        }
    }
}