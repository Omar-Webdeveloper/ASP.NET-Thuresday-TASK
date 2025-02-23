using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Thuresday_TASK.Controllers
{
    public class UserController : Controller
    {
        public const string SessionFirst_UserName = "_UserFirstName";
        public const string SessionSecnod_UserName = "_UserSecnodName";
        public const string SessionUserEmail = "_UserEmail";
        public const string SessionUserPassword = "_UserPassword";
        public const string SessionUserRepeatPassword = "_UserRepeatPassword"; 
        public const string SessionUserAddress = "_UserAddress";
        public const string SessionUserphone = "_UserRepeatphone";
        public const string CookieUserID = "UserId1";
        public const string CookieUserpPass = "Userpass1";


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TheLoginProsses()
        {

            string V_email = Request.Form["email"];

            string V_password = Request.Form["password"];

            string? UserName = HttpContext.Session.GetString(SessionUserEmail);
            string? UserId = HttpContext.Session.GetString(SessionUserPassword);


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

            if (V_email == UserName && V_password == UserId)
            {
                //if (User.RememberMe)
                //{
                //    CookieOptions option = new CookieOptions
                //    {
                //        Expires = DateTime.Now.AddDays(30);
                //    };
                //    Response.Cookies.Append("UserName", user.Username, option);
                //    Response.Cookies.Append("Password", user.Password, option);
                //}
                Response.Cookies.Append(CookieUserID, V_email, options);
                Response.Cookies.Append(CookieUserpPass, V_password, options);

                return RedirectToAction("Index", "Home");

            }
            else if (V_email == "Admin@gmail.com" && V_password == "Admin") 
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Login");
        }
        //[HttpPost]
        //public IActionResult TheCookies() 
        //{
        //    string V_email = Request.Form["email"];

        //    string V_password = Request.Form["password"];

        //    string? UserName = HttpContext.Session.GetString(SessionUserEmail);
        //    string? UserId = HttpContext.Session.GetString(SessionUserPassword);
        //    string V_RememberMe = Request.Form["RememberMe"];

        //    if (V_RememberMe != null && UserName != null && UserId != null)
        //    {
        //        CookieOptions options = new CookieOptions
        //        {
        //            Domain = "example.com", // Set the domain for the cookie
        //            Expires = DateTime.Now.AddDays(7), // Set expiration date to 7 days from now
        //            Path = "/", // Cookie is available within the entire application
        //            Secure = true, // Ensure the cookie is only sent over HTTPS
        //            HttpOnly = true, // Prevent client-side scripts from accessing the cookie
        //            MaxAge = TimeSpan.FromDays(7), // Another way to set the expiration time
        //            IsEssential = true // Indicates the cookie is essential for the application to function
        //        };
        //        Response.Cookies.Append(CookieUserID, V_email, options);
        //        Response.Cookies.Append(CookieUserpPass, V_password, options);
        //        return RedirectToAction("Index", "Home");

        //    }
        //    return RedirectToAction("Login");
        //}
        public IActionResult Rigster()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TheRegisterProsses()
        {


            string V_firstname = Request.Form["firstname"];

            string V_lastname = Request.Form["lastname"];

            string V_email = Request.Form["email"];

            string V_password = Request.Form["password"];

            string V_repeatpassword = Request.Form["repeatpassword"];
            string V_Address = Request.Form["Address"];

            string V_phone = Request.Form["phone"];

            //Storing Data into Session using SetString  method
            HttpContext.Session.SetString(SessionFirst_UserName, V_firstname);
            HttpContext.Session.SetString(SessionSecnod_UserName, V_lastname);
            HttpContext.Session.SetString(SessionUserEmail, V_email);
            HttpContext.Session.SetString(SessionUserPassword, V_password);
            HttpContext.Session.SetString(SessionUserRepeatPassword, V_repeatpassword);
            HttpContext.Session.SetString(SessionUserAddress, V_Address);
            HttpContext.Session.SetString(SessionUserphone, V_phone);



            if (V_password != V_repeatpassword)
            {
                TempData["msg"] = "Password and Confirm Password must be same";
                return RedirectToAction("Register");
            }

            return RedirectToAction("Login", "User");




        }
        public IActionResult Profile()
        {
            string? UserFirstName = HttpContext.Session.GetString(SessionFirst_UserName);
            string? UserSecondName = HttpContext.Session.GetString(SessionSecnod_UserName);
            string? UserEmail = HttpContext.Session.GetString(SessionUserEmail);
            string? UserAddress = HttpContext.Session.GetString(SessionUserAddress);
            string? UserPhone = HttpContext.Session.GetString(SessionUserphone);


            ViewData["UserFirstName"] = UserFirstName;
            ViewData["UserSecondName"] = UserSecondName;
            ViewData["UserEmail"] = UserEmail;
            ViewData["UserAddress"] = UserAddress;
            ViewData["UserPhone"] = UserPhone;
            return View();
        }
        public IActionResult EditProfile()
        {
            string? UserFirstName = HttpContext.Session.GetString(SessionFirst_UserName);
            string? UserSecondName = HttpContext.Session.GetString(SessionSecnod_UserName);
            string? UserEmail = HttpContext.Session.GetString(SessionUserEmail);
            string? UserAddress = HttpContext.Session.GetString(SessionUserAddress);
            string? UserPhone = HttpContext.Session.GetString(SessionUserphone);


            ViewData["UserFirstName"] = UserFirstName;
            ViewData["UserSecondName"] = UserSecondName;
            ViewData["UserEmail"] = UserEmail;
            ViewData["UserAddress"] = UserAddress;
            ViewData["UserPhone"] = UserPhone;





            return View();
        }
        [HttpPost]
        public IActionResult TheEditProfileProsses()
        {
            string V_firstname = Request.Form["new_name"];
            string V_lastname = Request.Form["newsecond_name"];
            string V_email = Request.Form["newemail"];
            string V_Address = Request.Form["newaddress"];
            string V_phone = Request.Form["newphone"];
            //Storing Data into Session using SetString  method
            HttpContext.Session.SetString(SessionFirst_UserName, V_firstname);
            HttpContext.Session.SetString(SessionSecnod_UserName, V_lastname);
            HttpContext.Session.SetString(SessionUserEmail, V_email);
            HttpContext.Session.SetString(SessionUserAddress, V_Address);
            HttpContext.Session.SetString(SessionUserphone, V_phone);
            return RedirectToAction("Profile", "User");
        }
        public IActionResult Logout() 
        {
            HttpContext.Session.Remove("_UserFirstName");
            HttpContext.Session.Remove("_UserSecnodName");
            HttpContext.Session.Remove("_UserEmail");
            HttpContext.Session.Remove("_UserPassword");
            HttpContext.Session.Remove("_UserRepeatPassword");
            HttpContext.Session.Remove("_UserAddress");
            HttpContext.Session.Remove("_UserRepeatphone");

            Response.Cookies.Delete(CookieUserpPass);
            Response.Cookies.Delete(CookieUserID);
            return View();
        }

    }
}
