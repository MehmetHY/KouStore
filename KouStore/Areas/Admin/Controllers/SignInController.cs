﻿using KouStore.Areas.Admin.Models;
using KouStore.Data;
using KouStore.Managers;
using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SignInController : Controller
    {
        private readonly AppDbContext _db;
        public SignInController(AppDbContext db)
        {
            _db = db;
        }

        [Route("[Area]/[Controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(new AdminViewModel());
        }
        [HttpPost]
        public IActionResult Index(FormModel model)
        {
            model.Setup(this, nameof(Index), RedirectToAction("Index", "Dashboard"), SignInManager.SignInAdmin, _db);
            if (model.IsFormValid(_db))
            {
                SignInManager.SignInAdmin(HttpContext.Session, model.Admin);
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
        [HttpGet]
        [Route("[Area]/[Controller]/[Action]")]
        public IActionResult Logout()
        {
            if (SignInManager.IsAdminSignedIn(HttpContext.Session))
            {
                SignInManager.LogOutAdmin(HttpContext.Session);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
