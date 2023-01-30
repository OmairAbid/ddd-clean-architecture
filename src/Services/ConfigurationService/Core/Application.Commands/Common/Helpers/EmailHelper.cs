using Application.Commands.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Helpers;
public class EmailHelper : IEmailHelper
{
    #region Public Methods

    public bool IsValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }



    #endregion Public Methods
}
