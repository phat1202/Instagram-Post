using CloudinaryDotNet;
using Google.Protobuf.WellKnownTypes;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Instagram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InsContext _context;
        public IFormFile FileUpLoaded;
        public HomeController(ILogger<HomeController> logger, InsContext context)
        {
            _logger = logger;
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(Post post, IFormFile image)
        {

            var uploadResult = new UpLoadFile();
            var status = new Post()
            {
                Content = post.Content,
                CreatedAt = DateTime.Now,
                ImageId = uploadResult.uploadImage(image),
                IsActive = true,
                IsDeleted = false
            };
            _context.Add(status);
            _context.SaveChanges();
            return RedirectToAction("Index");
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