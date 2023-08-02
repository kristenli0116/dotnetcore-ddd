using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Turakas.Identity.Common;

namespace Turakas.Identity.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserController> _logger;
    private readonly JwtHelper _jwtHelper;

    public UserController(ILogger<UserController> logger, IConfiguration configuration, JwtHelper jwtHelper)
    {
        _logger = logger;
        _configuration = configuration;
        _jwtHelper = jwtHelper;
    }

    [HttpGet]
    public ActionResult GetToken(string name)
    {
        var token = _jwtHelper.CreateToken(name);
        return Ok(new {access_token = token});
    }
}