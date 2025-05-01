using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.MessageServices;

namespace MS.WebUI.Areas.User.Controllers;

[Area("User")]
[Route("User/[controller]/[action]/{id?}")]
public class MessageController : Controller
{
    private readonly IUserService _userService;
    private readonly IMessageService _messageService;

    public MessageController(IUserService userService, IMessageService messageService)
    {
        _userService = userService;
        _messageService = messageService;
    }

    public async Task<IActionResult> Inbox()
    {
        var user = await _userService.GetUserInfo();
        var result = await _messageService.GetInboxMessageAsync(user.Id);
        return View(result);
    }

    public async Task<IActionResult> Sendbox()
    {
        var user = await _userService.GetUserInfo();
        var result = await _messageService.GetSendboxMessageAsync(user.Id);
        return View(result);
    }
}
