﻿using MS.UI.DtoLayer.MessageDtos;

namespace MS.WebUI.Services.MessageServices;

public interface IMessageService
{
    Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
    Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
    Task<int> GetTotalMessageCountByReceiverId(string id);
}
