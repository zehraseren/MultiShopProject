using MS.UI.DtoLayer.CommentDtos;

namespace MS.WebUI.Services.CommentServices;

public interface ICommentService
{
    Task<List<ResultCommentDto>> GetAllCommentAsync();
    Task CreateCommentAsync(CreateCommentDto ccdto);
    Task UpdateCommentAsync(UpdateCommentDto ucdto);
    Task DeleteCommentAsync(string id);
    Task<GetByIdCommentDto> GetByIdCommentAsync(string id);
    Task<List<ResultCommentDto>> CommentListByProductId(string id);
    Task<int> GetTotalCommentCount();
    Task<int> GetActiveCommentCount();
    Task<int> GetPassiveCommentCount();
}
