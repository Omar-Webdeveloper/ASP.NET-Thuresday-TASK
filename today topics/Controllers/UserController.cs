using Microsoft.AspNetCore.Mvc;
using today_topics.Models;
namespace today_topics.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;
        public UserController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["Message"] = "User registered successfully with validation.";
                return RedirectToAction("Register");
            }
            return View(user);
        }



        public IActionResult RegisterWithoutValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterWithoutValidation(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["Message"] = "User registered successfully without validation.";
                return RedirectToAction("RegisterWithoutValidation");
            }
            return View(user);
        }
    }
}
