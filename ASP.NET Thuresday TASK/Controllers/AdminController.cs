using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Thuresday_TASK.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin_DashBoard()
        {
            return View();
        }
    }
}
