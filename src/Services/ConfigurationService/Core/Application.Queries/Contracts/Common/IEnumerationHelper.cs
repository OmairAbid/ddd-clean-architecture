using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Contracts.Common;
public interface IEnumerationHelper
{
    #region Public Methods

    /// <summary>
    /// Get String Value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    string GetStringValue(Enum value);

    #endregion Public Methods
}
