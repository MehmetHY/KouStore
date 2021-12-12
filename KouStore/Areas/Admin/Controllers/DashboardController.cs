﻿using Microsoft.AspNetCore.Mvc;
using KouStore.Managers;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        [Route("[area]/[controller]/{id}")]
        [HttpGet]
        public IActionResult Index([FromRoute] int id)
        {
            bool isAuthorized = AdminLoginChecker.IsAuthorized(HttpContext.Session, id);
            if (!isAuthorized)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
