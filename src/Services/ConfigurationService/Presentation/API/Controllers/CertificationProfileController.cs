using API.Model;
using Application.Commands.Common.Models;
using Application.Commands.Features.AuthenticationProfile.Add;
using Application.Commands.Features.AuthenticationProfile.Delete;
using Application.Commands.Features.AuthenticationProfile.Update;
using Application.Commands.Features.CertificationProfile.Add;
using Application.Commands.Features.CertificationProfile.Delete;
using Application.Commands.Features.CertificationProfile.Update;
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
public class CertificationProfileController : AppControllerBase
{
    #region Private Fields

    private readonly ILogger<CertificationProfileController> _logger;
    private readonly IMediator _mediator;
    private readonly LoggedInUser _loggedInuser;

    #endregion Private Fields

    #region Public Constructor

    public CertificationProfileController(ILogger<CertificationProfileController> logger,
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
        return null;
    }

    [HttpGet("{Id:long}")]
    public async Task<ActionResult> GetById(long Id, CancellationToken cancellationToken)
    {
        return null;
    }


    [HttpPost]
    [SwaggerOperation(
    Summary = "Add a new certification profile API",
    Description = "Applications can call this API to create new authentication profile.\nOnly SigningHub Administrators have permission.",
    OperationId = "Add",
    Tags = new[] { "CertificationProfile" })]
    [SwaggerResponse(200, "The posted payload", type: typeof(AddCertificationProfileRequest))]
    public async Task<ActionResult> Add([FromBody, SwaggerRequestBody("The order payload", Required = true)]
                                        AddCertificationProfileRequest request,
                                        CancellationToken cancellationToken)
    {
        request.UserEmail = _loggedInuser.EmailAddress;
        BasicResponse<Profile> response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    
    [ProducesResponseType(statusCode: 200)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCertificationProfileRequest request, CancellationToken cancellationToken)
    {
        request.UserEmail = _loggedInuser.EmailAddress;
        BasicResponse response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }

    [HttpDelete("{Id:long}")]
    public async Task<IActionResult> Delete(long Id, CancellationToken cancellationToken)
    {
        DeleteCertificationProfileRequest request = new();
        request.Id = Id;
        request.UserEmail = _loggedInuser.EmailAddress;

        var response = await _mediator.Send(request, cancellationToken);

        return CommandResult(response);
    }
    #endregion Public Methods
}