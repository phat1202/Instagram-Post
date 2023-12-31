﻿using Instagram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Instagram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InsContext _context;
        public HomeController(ILogger<HomeController> logger, InsContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.Include(i => i.image)
                                             .Include(u => u.user)
                                             .ToList();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}