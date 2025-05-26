using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Areas.Admin.Models;
using MS.WebUI.Services.Interfaces;
using MS.WebUI.Services.CommentServices;
using MS.WebUI.Services.MessageServices;

namespace MS.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderComponentPartial : ViewComponent
{
    private readonly IUserService _userService;
    private readonly IMessageService _messageService;
    private readonly ICommentService _commentService;

    public _AdminLayoutHeaderComponentPartial(IUserService userService, IMessageService messageService, ICommentService commentService)
    {
        _userService = userService;
        _messageService = messageService;
        _commentService = commentService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetUserInfo();

        var inboxMessages = await _messageService.GetInboxMessageAsync(user.Id);

        var senderIds = inboxMessages.Select(m => m.SenderId).Distinct().ToList();

        var senders = await _userService.GetUsersByIdsAsync(senderIds);

        foreach (var message in inboxMessages)
        {
            var sender = senders.FirstOrDefault(s => s.Id == message.SenderId);
            if (sender != null)
            {
                message.SenderFullName = $"{sender.Name} {sender.Surname}";
            }
            else
            {
                message.SenderFullName = "Bilinmeyen Gönderen";
            }
        }

        var messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
        ViewBag.messageCount = messageCount;

        int commentCount = await _commentService.GetTotalCommentCount();
        ViewBag.commentCount = commentCount;

        var comments = await _commentService.GetAllCommentAsync();

        var model = new AdminHeaderViewModel
        {
            InboxMessages = inboxMessages,
            Comments = comments
        };

        return View(model);
    }
}
