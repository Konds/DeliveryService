/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Unity.Attributes;

namespace BusinessObjects
{
    /// <summary>
    /// Route
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.IRoute" />
    public sealed class Route : IRoute
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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId
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
        [Dependency]
        public IPoint StartPoint { get; set; }
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        [Dependency]
        public IPoint EndPoint { get; set; }
        /// <summary>
        /// Gets or sets the route cost.
        /// </summary>
        /// <value>
        /// The route cost.
        /// </value>
        [Dependency]
        public IRouteCost RouteCost { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Route"/> class.
        /// </summary>
        public Route()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Route"/> class.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="routeCost">The route cost.</param>
        public Route(string objectId, IPoint startPoint, IPoint endPoint, IRouteCost routeCost)
        {
            ObjectId = objectId;
            StartPoint = startPoint;
            EndPoint = endPoint;
            RouteCost = routeCost;
        }

        #endregion

        #region Private & Internal Methods
        #endregion

        #region Public Methods
        #endregion

        #region Event handling Methods
        #endregion
    }
}
