using Account.Application.Command;
using Account.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AZ_Account.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var users = await _mediator.Send(new GetUserQuery());
        return Ok(users);
    }
    [HttpPost("GetUserByEmail")]
    public async Task<IActionResult> GetUserById([FromBody]GetUserByIdQuery query)
    {
        var user = await _mediator.Send(query);
        return Ok(user);
    }
}

