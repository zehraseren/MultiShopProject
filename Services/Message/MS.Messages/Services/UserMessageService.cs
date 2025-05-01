using AutoMapper;
using MS.Message.Dtos;
using MS.Message.DAL.Context;
using MS.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MS.Message.Services;

public class UserMessageService : IUserMessageService
{
    private readonly IMapper _mapper;
    private readonly MessageContext _context;

    public UserMessageService(IMapper mapper, MessageContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task CreateMessageAsync(CreateMessageDto cmdto)
    {
        var result = _mapper.Map<UserMessage>(cmdto);
        await _context.UserMessages.AddAsync(result);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ResultMessageDto>> GetAllMessageAsync()
    {
        var result = await _context.UserMessages.ToListAsync();
        return _mapper.Map<List<ResultMessageDto>>(result);
    }

    public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
    {
        var result = await _context.UserMessages.FindAsync(id);
        return _mapper.Map<GetByIdMessageDto>(result);
    }

    public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
    {
        var result = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
        return _mapper.Map<List<ResultInboxMessageDto>>(result);
    }

    public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
    {
        var result = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
        return _mapper.Map<List<ResultSendboxMessageDto>>(result);
    }

    public async Task<int> GetTotalMessageCount()
    {
        int result = await _context.UserMessages.CountAsync();
        return result;
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var result = await _context.UserMessages.Where(x => x.ReceiverId == id)
            .CountAsync();
        return result;
    }

    public async Task RemoveMessageAsync(int it)
    {
        var result = await _context.UserMessages.FindAsync(it);
        _context.UserMessages.Remove(result);
    }

    public async Task UpdateMessageAsync(UpdateMessageDto umdto)
    {
        var result = _mapper.Map<UserMessage>(umdto);
        _context.UserMessages.Update(result);
        await _context.SaveChangesAsync();
    }
}
