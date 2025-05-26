using MS.Comment.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MS.Comment.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CommentStatisticsController : ControllerBase
{
    private readonly CommentContext _context;

    public CommentStatisticsController(CommentContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommentCount()
    {
        int result = await _context.UserComments.CountAsync();
        return Ok(result);
    }
}
