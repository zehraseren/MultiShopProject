using MS.Message.Dtos;
using MS.Message.Services;
using Microsoft.AspNetCore.Mvc;

namespace MS.Message.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessagesController : ControllerBase
{
    private readonly IUserMessageService _userMessageService;

    public UserMessagesController(IUserMessageService userMessageService)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMessage()
    {
        var result = await _userMessageService.GetAllMessageAsync();
        return Ok(result);
    }

    [HttpGet("GetMessageInbox")]
    public async Task<IActionResult> GetMessageInbox(string id)
    {
        var result = await _userMessageService.GetInboxMessageAsync(id);
        return Ok(result);
    }

    [HttpGet("GetMessageSendbox")]
    public async Task<IActionResult> GetMessageSendbox(string id)
    {
        var result = await _userMessageService.GetSendboxMessageAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage(CreateMessageDto cmdto)
    {
        await _userMessageService.CreateMessageAsync(cmdto);
        return Ok("Mesaj başarıyla eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveMessage(int id)
    {
        await _userMessageService.RemoveMessageAsync(id);
        return Ok("Mesaj başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMessage(UpdateMessageDto umdto)
    {
        await _userMessageService.UpdateMessageAsync(umdto);
        return Ok("Mesaj başarıyla güncellendi.");
    }

    [HttpGet("GetTotalMessageCount")]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        var result = await _userMessageService.GetTotalMessageCount();
        return Ok(result);
    }

    [HttpGet("GetTotalMessageCountByReceiverId")]
    public async Task<IActionResult> GetTotalMessageCountByReceiverI(string id)
    {
        var result = await _userMessageService.GetTotalMessageCountByReceiverId(id);
        return Ok(result);
    }
}
