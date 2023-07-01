using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InsContext _context;
        public PostController(ILogger<HomeController> logger, InsContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(Post post, IFormFile image)
        {
            if (image == null)
            {
                ModelState.AddModelError("", "Please insert picture");
                return View();
            }
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
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult Like(Reaction react, int postId)
        //{
        //    var post = _context.Posts.Where(p => p.Id == postId).FirstOrDefault();
        //    if (post == null)
        //    {
        //        ModelState.AddModelError("", "Bài viết không tồn tại!");
        //    }
        //    post.ReId = react.ReId;
        //    var reaction = new Reaction()
        //    {
        //        Like = react.Like,
        //        Comment = react.Comment,
        //        PostId = postId,
        //        UserId = 2,
        //    };
        //    _context.Add(reaction);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index","Home");
        //}
    }

}
