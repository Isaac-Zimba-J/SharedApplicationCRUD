using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Server.Services;
using Shared.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService service) : Controller
{
    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<Register>>> Register(Register user)
    {
        if (ModelState.IsValid)
        {
            return await service.RegisterUser(user);
        }
        return BadRequest();

    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<Login>>> Login(Login user)
    {
        if (ModelState.IsValid)
        {
            return await service.LoginUser(user);
        }

        return BadRequest();
    }
}