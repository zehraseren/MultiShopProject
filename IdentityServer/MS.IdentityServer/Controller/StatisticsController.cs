using Microsoft.AspNetCore.Mvc;
using MS.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace MS.IdentityServer.Controller;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public StatisticsController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet()]
    public IActionResult GetUserCount()
    {
        int userCount = _userManager.Users.Count();
        return Ok(userCount);
    }
}
