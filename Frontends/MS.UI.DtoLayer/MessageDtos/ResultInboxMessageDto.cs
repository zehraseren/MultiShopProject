namespace MS.UI.DtoLayer.MessageDtos;

public class ResultInboxMessageDto
{
    public int UserMessageId { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public DateTime MessageDate { get; set; }
    public string SenderFullName { get; set; }
}
