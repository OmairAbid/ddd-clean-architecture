using API.Model;

using Application.Commands.Features.Update;
using Application.Queries.Common.Models;
using Application.Queries.Features.SystemSettings;

using Command = Application.Commands.Common.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemSettingController : AppControllerBase
{
    #region Private Fields

    private readonly ILogger<SystemSettingController> _logger;
    private readonly IMediator _mediator;
    private readonly LoggedInUser _loggedInuser;

    #endregion Private Fields

    #region Public Constructors

    public SystemSettingController(IMediator mediator, LoggedInUser user,
        ILogger<SystemSettingController> logger
        )
    {
        _mediator = mediator;
        _logger = logger;
        _loggedInuser = user;
    }

    #endregion Public Constructors

    #region Public Methods

    [HttpGet]
    public async Task<ActionResult<QueryResponse<List<GetSystemSettingQueryResponse>>>> Get()
    {
        QueryResponse<List<GetSystemSettingQueryResponse>> response = await _mediator.Send(new GetSystemSettingQueryRequest());

        return Result(response);
    }

    [ApiExplorerSettings(IgnoreApi = false)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSystemSettingRequest request)
    {
        Command.BasicResponse response = await _mediator.Send(request);
        return CommandResult(response);
    }

    #endregion Public Methods
}