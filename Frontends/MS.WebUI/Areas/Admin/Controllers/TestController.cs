﻿using Microsoft.AspNetCore.Mvc;

namespace MS.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
