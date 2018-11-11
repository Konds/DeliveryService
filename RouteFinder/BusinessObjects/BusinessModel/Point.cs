/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BusinessObjects
{
    /// <summary>
    /// Point
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.IPoint" />
    public sealed class Point : IPoint
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
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Point()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="name">The name.</param>
        public Point(string objectId, string name)
        {
            ObjectId = objectId;
            Name = name;
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
