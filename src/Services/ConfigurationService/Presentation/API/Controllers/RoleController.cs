using API.Model;
using Application.Queries.Common.Models;
using Application.Queries.Features.Role;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : AppControllerBase
{
    #region Private Fields

    private readonly ILogger<RoleController> _logger;
    private readonly IMediator _mediator;
    private readonly LoggedInUser _loggedInuser;

    #endregion Private Fields

    #region Public Constructor

    public RoleController(ILogger<RoleController> logger,
        IMediator mediator, LoggedInUser user)
    {
        _logger = logger;
        _mediator = mediator;
        _loggedInuser = user;
    }

    #endregion Public Constructor

    #region Public Methods

    [HttpGet]
    public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        QueryResponse<List<GetAllAdministratorRoleResponse>> response = await _mediator.Send(new GetAllRolesQueryRequest(), cancellationToken);

        return Result(response);
    }

    [HttpGet("{Id:long}")]
    public async Task<ActionResult> GetById(long Id, CancellationToken cancellationToken)
    {
        QueryResponse<AdministratorRoleQueryResponse> response = await _mediator.Send(new GetRoleByIdQueryRequest() { RoleId = Id }, cancellationToken);

        return Result(response);
    }

    #endregion Public Methods
}