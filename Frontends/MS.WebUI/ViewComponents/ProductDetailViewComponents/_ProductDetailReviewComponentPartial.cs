using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CommentServices;

namespace MS.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailReviewComponentPartial : ViewComponent
{
    private readonly ICommentService _commentService;

    public _ProductDetailReviewComponentPartial(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var result = await _commentService.CommentListByProductId(id);
        return View(result);
    }
}