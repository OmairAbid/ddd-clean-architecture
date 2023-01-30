using Application.Queries.Common.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

using Command = Application.Commands.Common.Models;

namespace API.Controllers
{
    public class AppControllerBase : ControllerBase, IActionFilter
    {
        #region Public Methods

        [NonAction]
        public ObjectResult CommandResult(Command.BasicResponse response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [NonAction]
        public ObjectResult CommandResult<T>(Command.BasicResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [NonAction]
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        [NonAction]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerActionDescriptor actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            object[] anonymousAttributes = actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), true);

            if (anonymousAttributes.Length > 0)
            {
                return;
            }
        }

        [NonAction]
        public ObjectResult Result<T>(QueryResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        #endregion Public Methods
    }
}