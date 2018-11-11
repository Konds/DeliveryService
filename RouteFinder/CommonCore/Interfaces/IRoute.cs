/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces
{
    /// <summary>
    /// Interface to provide Route Information.
    /// </summary>
    public interface IRoute
    {
        #region Private Variables
        #endregion

        #region Public Variables
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>
        /// The object identifier.
        /// </value>
        string ObjectId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start point.
        /// </summary>
        /// <value>
        /// The start point.
        /// </value>
        IPoint StartPoint { get; set; }

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        IPoint EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the route cost.
        /// </summary>
        /// <value>
        /// The route cost.
        /// </value>
        IRouteCost RouteCost { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Private & Internal Methods
        #endregion

        #region Public Methods
        #endregion

        #region Event handling Methods
        #endregion
    }
}