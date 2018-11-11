/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

namespace CommonCore.Interfaces
{
    /// <summary>
    /// IRouteContext
    /// </summary>
    public interface IRouteCost
    {
        #region Private Variables
        #endregion

        #region Public Variables
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the time cost.
        /// </summary>
        /// <value>
        /// The time cost.
        /// </value>
        ITimeCostValue TimeCost { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        ICostValue Cost { get; set; }

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
