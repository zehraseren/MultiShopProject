using MS.Comment.Context;
using MS.Comment.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MS.Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentContext _context;

    public CommentsController(CommentContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult CommentList()
    {
        var values = _context.UserComments.ToList();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult AddComment(UserComment comment)
    {
        _context.UserComments.Add(comment);
        _context.SaveChanges();
        return Ok("Yorum eklendi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        var comment = _context.UserComments.Find(id);
        return Ok(comment);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComment(int id)
    {
        var comment = _context.UserComments.Find(id);
        _context.UserComments.Remove(comment);
        _context.SaveChanges();
        return Ok("Yorum silindi.");
    }

    [HttpPut]
    public IActionResult UpdateComment(UserComment comment)
    {
        _context.UserComments.Update(comment);
        _context.SaveChanges();
        return Ok("Yorum güncellendi.");
    }

    [HttpGet("CommmentListByProductId/")]
    public IActionResult CommmentListByProductId(string productId)
    {
        var values = _context.UserComments.Where(x => x.ProductId == productId).ToList();
        return Ok(values);
    }

    [HttpGet("GetActiveCommentCount")]
    public IActionResult GetActiveCommentCount()
    {
        var values = _context.UserComments.Where(x => x.Status == true).Count();
        return Ok(values);
    }

    [HttpGet("GetPassiveCommentCount")]
    public IActionResult GetPassiveCommentCount()
    {
        var values = _context.UserComments.Where(x => x.Status == false).Count();
        return Ok(values);
    }

    [HttpGet("GetTotalCommentCount")]
    public IActionResult GetTotalCommentCount()
    {
        var values = _context.UserComments.Count();
        return Ok(values);
    }
}
