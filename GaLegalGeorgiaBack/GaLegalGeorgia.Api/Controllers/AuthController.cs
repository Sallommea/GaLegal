using GaLegalGeorgia.Application.Features.Admin.Queries.getUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GaLegalGeorgia.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<string> Authorize(AdminQuery adminQuery)
    {
        var result = await _mediator.Send(adminQuery);
        return result;
    }
}
