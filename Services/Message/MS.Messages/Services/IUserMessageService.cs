using MS.Message.Dtos;

namespace MS.Message.Services;

public interface IUserMessageService
{
    Task<List<ResultMessageDto>> GetAllMessageAsync();
    Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
    Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
    Task CreateMessageAsync(CreateMessageDto cmdto);
    Task UpdateMessageAsync(UpdateMessageDto umdto);
    Task RemoveMessageAsync(int it);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    Task<int> GetTotalMessageCount();
    Task<int> GetTotalMessageCountByReceiverId(string id);
}
