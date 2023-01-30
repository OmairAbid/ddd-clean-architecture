using Application.Queries.Common.Models;
using Application.Queries.Features;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoggingController : ControllerBase
{
    #region Private Fields

    private readonly ILogger<LoggingController> _logger;
    private readonly IMediator _mediator;

    #endregion Private Fields

    #region Public Constructor

    public LoggingController(IMediator mediator, ILogger<LoggingController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    #endregion Public Constructor

    #region Public Methods

    [HttpPost(Name = "GetAdministratorLogs")]
    public async Task<ActionResult<BasicResponse<List<GetAdministratorLogResponse>>>> Get(GetAdministratorLogsRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    #endregion Public Methods
}