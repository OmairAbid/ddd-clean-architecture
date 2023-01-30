using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Contracts.Common;
public interface IEmailHelper
{
    /// <summary>
    /// Validate email for null, and format
    /// </summary>
    /// <param name="email"></param>
    /// <returns>true if email is valid email, otherwise false</returns>
    bool IsValidEmail(string email);
}
