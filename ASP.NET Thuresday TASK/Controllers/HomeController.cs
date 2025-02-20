using System.Diagnostics;
using ASP.NET_Thuresday_TASK.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Thuresday_TASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionFirst_UserName = "_UserFirstName";
        public const string SessionSecnod_UserName = "_UserSecnodName";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string? UserFirstName = HttpContext.Session.GetString(SessionFirst_UserName);
            string? UserSecondName = HttpContext.Session.GetString(SessionSecnod_UserName);
            ViewData["UserFirstName"] = UserFirstName;
            ViewData["UserSecondName"] = UserSecondName;
            return View();
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
