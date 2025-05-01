using AutoMapper;
using MS.Message.DAL.Entities;
using MS.Message.Dtos;

namespace MS.Message.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
        CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
        CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
        CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
    }
}
