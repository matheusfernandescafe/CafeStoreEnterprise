﻿using Microsoft.AspNetCore.Mvc;

namespace CSE.WebApp.MVC.Extensions;

public class SummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
