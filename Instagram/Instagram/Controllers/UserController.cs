using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class UserController : Controller
    {
        private readonly InsContext? _context;
        public UserController(InsContext? context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Userz> users = _context.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Userz user)
        {
            var dup_user = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            string special = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            if (dup_user != null)
            {
                ModelState.AddModelError("", "User exists");
                return View();
            }
            if (user.UserName.Any(char.IsUpper) || user.UserName.Any(char.IsWhiteSpace))
            {
                ModelState.AddModelError("", "No special character, space, and uppercase letter.");
                return View();
            }
            foreach (var s in special)
            {
                if (user.UserName.Contains(s))
                {
                    ModelState.AddModelError("", "No special character, space, and uppercase letter.");
                    return View();
                }
            }

            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string uid, string pass)
        {

            var account = _context.Users.Where(u => u.UserName == uid && u.Password == pass).FirstOrDefault();
            if (account == null)
            {
                ModelState.AddModelError("", "Your username or password is wrong.");
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string username, string oldPassword, string newPassword)
        {

            var account = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            var password = _context.Users.Where(p => p.Password == oldPassword).FirstOrDefault();
            if (account == null)
            {
                ModelState.AddModelError("", "This username doesn't exist");
                return View();
            }
            if (password == null)
            {
                ModelState.AddModelError("", "Current password is wrong, try again.");
                return View();
            }
            if (newPassword == account.Password)
            {
                ModelState.AddModelError("", "Your new password must be different from your previous password.");
                return View();
            }
            account.Password = newPassword;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
