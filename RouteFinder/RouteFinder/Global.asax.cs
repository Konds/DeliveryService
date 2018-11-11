/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;

namespace RouteFinder
{
    /// <summary>
    /// The Web Application Start
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Applications the start.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
