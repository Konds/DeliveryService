using CommonCore.Interfaces;
using System;
using Unity.Attributes;

namespace BusinessObjects.BusinessModel
{
    /// <summary>
    /// RouteCost 
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.IRouteCost" />
    public class RouteCost : IRouteCost
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
        [Dependency]
        public ITimeCostValue TimeCost { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        [Dependency]
        public ICostValue Cost { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteCost"/> class.
        /// </summary>
        public RouteCost()
        { }

        public RouteCost(ITimeCostValue timeCost, ICostValue cost)
        {
            TimeCost = timeCost ?? throw new ArgumentNullException(nameof(timeCost));
            Cost = cost ?? throw new ArgumentNullException(nameof(cost));
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
