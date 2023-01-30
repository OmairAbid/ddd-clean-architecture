using API.Model;
using Application.Commands.Common.Models;
using Application.Commands.Features.AuthenticationProfile.Add;
using Application.Commands.Features.AuthenticationProfile.Delete;
using Application.Commands.Features.AuthenticationProfile.Update;
using Application.Commands.Features.Connectors.Delete;
using Application.Queries.Common.Models;
using Application.Queries.Features.Role;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class AuthenticationProfileController : AppControllerBase
{
    #region Private Fields

    private readonly ILogger<AuthenticationProfileController> _logger;
    private readonly IMediator _mediator;
    private readonly LoggedInUser _loggedInuser;

    #endregion Private Fields

    #region Public Constructor

    public AuthenticationProfileController(ILogger<AuthenticationProfileController> logger,
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
        QueryResponse<List<ProfilesQueryResponse>> response = await _mediator.Send(new GetAllAuthenticationProfilesRequest(), cancellationToken);

        return Result(response);
    }

    [HttpGet("{Id:long}")]
    public async Task<ActionResult> GetById(long Id, CancellationToken cancellationToken)
    {
        QueryResponse<ProfilesQueryResponse> response = await _mediator.Send(new GetAuthenticationProfileByIdRequest() { Id = Id }, cancellationToken);

        return Result(response);
    }


    [HttpPost]
    [SwaggerOperation(
    Summary = "Add a new authentication profile API",
    Description = "Applications can call this API to create new authentication profile.\nOnly SigningHub Administrators have permission.",
    OperationId = "Add",
    Tags = new[] { "AuthenticationProfile" })]
    [SwaggerResponse(200, "The posted payload", type: typeof(AddAuthenticationProfileRequest))]
    public async Task<ActionResult> Add([FromBody, SwaggerRequestBody("The order payload", Required = true)]
                                        AddAuthenticationProfileRequest request,
                                        CancellationToken cancellationToken)
    {
        request.UserEmail = _loggedInuser.EmailAddress;
        BasicResponse<Profile> response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    /// <summary>
    /// Update Authentication Profile
    /// </summary>
    /// <param name="request"></param>
    /// <remarks>Applications can call this API to update authentication profile.
    /// Only SigningHub Administrators have permission.
    /// <returns></returns>
    [ProducesResponseType(statusCode: 200)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateAuthenticationProfileRequest request, CancellationToken cancellationToken)
    {
        request.UserEmail = _loggedInuser.EmailAddress;
        BasicResponse response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    [HttpDelete("{Id:long}")]
    public async Task<IActionResult> Delete(long Id, CancellationToken cancellationToken)
    {
        DeleteAuthenticationProfileRequest request = new();
        request.Id = Id;
        request.UserEmail = _loggedInuser.EmailAddress;

        var response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }
    #endregion Public Methods
}