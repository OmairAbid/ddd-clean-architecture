using API.Model;
using Application.Commands.Common.Enumerations;
using Application.Commands.Common.Models;
using Application.Commands.Features.Connectors.Add;
using Application.Commands.Features.Connectors.Delete;
using Application.Commands.Features.Connectors.Update;
using Application.Queries.Common.Models;
using Application.Queries.Features.Connectors.Get;
using Application.Queries.Features.SystemSettings;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ConnectorController : AppControllerBase
{
    #region Private Fields

    private readonly ILogger<ConnectorController> _logger;
    private readonly IMediator _mediator;
    private readonly LoggedInUser _loggedInuser;

    #endregion

    #region Public Constructor

    public ConnectorController(ILogger<ConnectorController> logger,
        IMediator mediator, LoggedInUser user)
    {
        _logger = logger;
        _mediator = mediator;
        _loggedInuser = user;
    }

    #endregion

    #region Public Methods

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
    {
        QueryResponse<List<GetConnectorQueryResponse>> response = await _mediator.Send(new GetConnectorsQueryRequest(), cancellationToken);

        return Result(response);
    }

    [HttpGet("GetProvider/{providerName}")]
    public async Task<ActionResult> GetProvider([FromRoute] string providerName, CancellationToken cancellationToken)
    {
        GetProviderQueryRequest request = new();
        request.ProviderName = providerName;
        request.UserEmail = _loggedInuser.EmailAddress;
        QueryResponse<ConnectionProviderQueryResponse> response = await _mediator.Send(request, cancellationToken);

        return Result(response);
    }

    [HttpGet("GetAllProviderParameters")]
    public async Task<ActionResult> GetAllProviderParameters(CancellationToken cancellationToken)
    {
        GetAllProviderParametersQueryRequest request = new();
        request.UserEmail = _loggedInuser.EmailAddress;
        QueryResponse<IEnumerable<ConnectionProviderParametersQueryResponse>> response = await _mediator.Send(request, cancellationToken);

        return Result(response);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddConnectorRequest request, CancellationToken cancellationToken)
    {
        request.UserEmail = _loggedInuser.EmailAddress;

        var response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update(UpdateConnectorRequest request, CancellationToken cancellationToken)
    {
        
        request.UserEmail = _loggedInuser.EmailAddress;
        
        var response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    [HttpDelete("{ConnectorName}")]
    public async Task<IActionResult> Delete(string ConnectorName, CancellationToken cancellationToken)
    {
        DeleteConnectorRequest request = new();
        request.ConnectorName = ConnectorName;
        request.UserEmail = _loggedInuser.EmailAddress;

        var response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    #endregion

}
