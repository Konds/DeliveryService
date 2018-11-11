/*
<FileInfo>
  <Author>Pedro Azevedo</Author>
  <Copyright>Delivery Service 2018</Copyright>
</FileInfo>
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Interfaces
{
    /// <summary>
    /// ICostValue
    /// </summary>
    public interface ICostValue
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
        int Value { get; set; }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>
        /// The start value.
        /// </value>
        int StartValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        int MaxValue { get; set; }

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
