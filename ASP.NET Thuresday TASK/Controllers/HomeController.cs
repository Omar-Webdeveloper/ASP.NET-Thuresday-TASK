using System.Diagnostics;
using ASP.NET_Thuresday_TASK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASP.NET_Thuresday_TASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionFirst_UserName = "_UserFirstName";
        public const string SessionSecnod_UserName = "_UserSecnodName";
        public const string SessionUserEmail = "_UserEmail";
        public const string SessionUserPassword = "_UserPassword";
        public const string SessionUserRepeatPassword = "_UserRepeatPassword";
        public const string SessionUserAddress = "_UserAddress";
        public const string SessionUserphone = "_UserRepeatphone";
        public const string CookieUserID = "UserId1";
        public const string CookieUserpPass = "Userpass1";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var message = TempData["Message"]?.ToString();
            ViewData["Message"] = message;

            string? UserFirstName = HttpContext.Session.GetString(SessionFirst_UserName);
            string? UserSecondName = HttpContext.Session.GetString(SessionSecnod_UserName);
            string? UserEmail = HttpContext.Session.GetString(SessionUserEmail);
            string? UserPass = HttpContext.Session.GetString(SessionUserPassword);
            string? UserRepat_Pass = HttpContext.Session.GetString(SessionUserRepeatPassword);
            CookieOptions options = new CookieOptions
            {
                Domain = "example.com", // Set the domain for the cookie
                Expires = DateTime.Now.AddDays(7), // Set expiration date to 7 days from now
                Path = "/", // Cookie is available within the entire application
                Secure = true, // Ensure the cookie is only sent over HTTPS
                HttpOnly = true, // Prevent client-side scripts from accessing the cookie
                MaxAge = TimeSpan.FromDays(7), // Another way to set the expiration time
                IsEssential = true // Indicates the cookie is essential for the application to function
            };
            if (UserEmail != null && UserPass != null)
            {
                Response.Cookies.Append(CookieUserID, UserEmail, options);
                Response.Cookies.Append(CookieUserpPass, UserPass, options);
            }
       
            ViewData["UserFirstName"] = UserFirstName;
            ViewData["UserSecondName"] = UserSecondName;

            string? UserName = Request.Cookies.ContainsKey(CookieUserID) ? Request.Cookies[CookieUserID] : null;
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
