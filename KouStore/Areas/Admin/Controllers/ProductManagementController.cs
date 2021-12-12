﻿using KouStore.Data;
using KouStore.Managers;
using KouStore.Models;
using KouStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductManagementController : Controller
    {
        private readonly AppDbContext _db;
        public ProductManagementController(AppDbContext db)
        {
            _db = db;
        }
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!AdminLoginManager.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Login");
            }
            return View(_db.GetAllProducts());
        }
        [Route("[area]/[controller]/[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            if (!AdminLoginManager.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Login");
            }
            return View(new ProductManageViewModel(_db));
        }
        [Route("[area]/[controller]/[action]")]
        [HttpPost]
        public IActionResult Create(ProductManageViewModel model)
        {
            if (!AdminLoginManager.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index");
        }
    }
}