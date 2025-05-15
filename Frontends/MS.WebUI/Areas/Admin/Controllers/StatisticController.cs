using Microsoft.AspNetCore.Mvc;
using MS.WebUI.Services.CommentServices;
using MS.WebUI.Services.StatisticServices.UserStatisticServices;
using MS.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MS.WebUI.Services.StatisticServices.MessageStatisticServices;
using MS.WebUI.Services.StatisticServices.DiscountStatisticServices;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class StatisticController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IUserStatisticService _userStatisticService;
    private readonly ICatalogStatisticService _catalogStatisticService;
    private readonly IMessageStatisticService _messageStatisticService;
    private readonly IDiscountStatisticService _discountStatisticService;

    public StatisticController(ICommentService commentService, IUserStatisticService userStatisticService, ICatalogStatisticService catalogStatisticService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticService)
    {
        _commentService = commentService;
        _userStatisticService = userStatisticService;
        _catalogStatisticService = catalogStatisticService;
        _messageStatisticService = messageStatisticService;
        _discountStatisticService = discountStatisticService;
    }

    public async Task<IActionResult> Index()
    {
        var getBrandCount = await _catalogStatisticService.GetBrandCount();
        var getProductCount = await _catalogStatisticService.GetProductCount();
        var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
        var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
        var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
        var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

        var getUserCount = await _userStatisticService.GetUsercount();

        var getTotalCommentCount = await _commentService.GetAllCommentAsync();
        var getActiveCommentCount = await _commentService.GetAllCommentAsync();
        var getPassiveCommentCount = await _commentService.GetAllCommentAsync();

        var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

        var getTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();

        ViewBag.getBrandCount = getBrandCount;
        ViewBag.getProductCount = getProductCount;
        ViewBag.getCategoryCount = getCategoryCount;
        ViewBag.getProductAvgPrice = getProductAvgPrice;
        ViewBag.getMaxPriceProductName = getMaxPriceProductName;
        ViewBag.getMinPriceProductName = getMinPriceProductName;

        ViewBag.getUserCount = getUserCount;

        ViewBag.getTotalCommentCount = getTotalCommentCount.Count;
        ViewBag.getActiveCommentCount = getActiveCommentCount.Count;
        ViewBag.getPassiveCommentCount = getPassiveCommentCount.Count;

        ViewBag.getDiscountCouponCount = getDiscountCouponCount;

        ViewBag.getTotalMessageCount = getTotalMessageCount;

        return View();
    }
}
