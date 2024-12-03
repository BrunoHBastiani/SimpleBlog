using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Application.DTOs.Users.Requests;
using SimpleBlog.Application.DTOs.Users.Responses;
using SimpleBlog.Application.Exceptions;
using SimpleBlog.Application.Interfaces;
using System.Net;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
    {
        try
        {
            await _userService.CreateAsync(request);
            return Created(string.Empty, null);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] AuthenticateRequest request)
    {
        try
        {
            AuthenticateResponse authenticationResponse = await _userService.AuthenticateAsync(request);
            return Ok(authenticationResponse);
        }
        catch (HttpException e)
        {
            return StatusCode(e.StatusCode, e.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro durante o processamento. Tente novamente em alguns minutos");
        }
    }
}
