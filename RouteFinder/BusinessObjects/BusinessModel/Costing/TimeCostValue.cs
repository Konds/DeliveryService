/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using CommonCore.Interfaces;

namespace BusinessObjects.BusinessModel
{
    /// <summary>
    /// TimeCostValue
    /// </summary>
    /// <seealso cref="CommonCore.Interfaces.ITimeCostValue" />
    public class TimeCostValue : ITimeCostValue
    {
        #region Private Variables

        #endregion

        #region Public Variables
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }
        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>
        /// The start value.
        /// </value>
        public int StartValue { get; set; } = int.MinValue;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public int MaxValue { get; set; } = int.MaxValue;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeCostValue"/> class.
        /// </summary>
        public TimeCostValue()
        {
            Value = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeCostValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public TimeCostValue(int value, int startValue, int maxValue)
        {
            Value = value;
            StartValue = startValue;
            MaxValue = maxValue;
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
