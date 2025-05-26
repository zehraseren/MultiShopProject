using MS.Message.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MS.Message.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserMessageStatisticsController : ControllerBase
{
    private readonly IUserMessageService _userMessageServices;

    public UserMessageStatisticsController(IUserMessageService userMessageServices)
    {
        _userMessageServices = userMessageServices;
    }

    [HttpGet("GetMessageCount")]
    public async Task<IActionResult> GetMessageCount()
    {
        int result = await _userMessageServices.GetTotalMessageCount();
        return Ok(result);
    }
}
