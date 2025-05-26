using MS.UI.DtoLayer.CommentDtos;
using MS.UI.DtoLayer.MessageDtos;

namespace MS.WebUI.Areas.Admin.Models;

public class AdminHeaderViewModel
{
    public List<ResultInboxMessageDto> InboxMessages { get; set; }
    public List<ResultCommentDto> Comments { get; set; }
}
