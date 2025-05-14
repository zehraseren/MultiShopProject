using Microsoft.AspNetCore.Mvc;
using MS.Catalog.Services.StatisticServices;

namespace MS.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    [HttpGet("GetBrandCount")]
    public async Task<IActionResult> GetBrandCount()
    {
        var result = await _statisticService.GetBrandCount();
        return Ok(result);
    }

    [HttpGet("GetCategoryCount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        var result = await _statisticService.GetCategoryCount();
        return Ok(result);
    }

    [HttpGet("GetProductCount")]
    public async Task<IActionResult> GetProductCount()
    {
        var result = await _statisticService.GetProductCount();
        return Ok(result);
    }

    [HttpGet("GetMinPriceProductName")]
    public async Task<IActionResult> GetMinPriceProductName()
    {
        var result = await _statisticService.GetMinPriceProductName();
        return Ok(result);
    }

    [HttpGet("GetMaxPriceProductName")]
    public async Task<IActionResult> GetMaxPriceProductName()
    {
        var result = await _statisticService.GetMaxPriceProductName();
        return Ok(result);
    }

    [HttpGet("GetProductAvgPrice")]
    public async Task<IActionResult> GetProductAvgPrice()
    {
        var result = await _statisticService.GetProductAvgPrice();
        return Ok(result);
    }
}
