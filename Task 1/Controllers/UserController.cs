using Microsoft.AspNetCore.Mvc; // Import the necessary namespaces for ASP.NET Core MVC
using Microsoft.EntityFrameworkCore; // Import Entity Framework Core for database operations
using Task_1.Models; // Import the models from your project namespace

namespace Task_1.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context; // Declare a private readonly field for the database context

        public UserController(MyDbContext context) // Constructor that takes a MyDbContext instance as a parameter
        {
            _context = context; // Assign the passed-in context to the private field
        }
        public IActionResult Index()
        {
            return View();
        }


        // GET: Users/All_users
        public async Task<IActionResult> All_users() // Define an action method that returns a Task of IActionResult
        {
            var users = await _context.Users.ToListAsync(); // Retrieve all users from the database asynchronously
            return View(users); // Return the view with the list of users
        }

        // GET: Users/Create
        public IActionResult Create() // Define a GET action method named Create
        {
            return View(); // Return the Create view to display the form for creating a new user
        }

        // POST: Users/Create
        [HttpPost] // Specify that this is a POST action method
        public async Task<IActionResult> Create([Bind("Name,Email")] User user) // Define a POST action method named Create that takes a User object as a parameter
        {
            if (ModelState.IsValid) // Check if the model state is valid (i.e., the data received from the form is valid according to the model's validation rules)
            {
                _context.Add(user); // Add the new user to the database context
                await _context.SaveChangesAsync(); // Save the changes to the database asynchronously
                return RedirectToAction(nameof(All_users)); // Redirect to the All_users action after successfully saving the new user
            }
            return View(user); // If the model state is not valid, return the Create view with the user object to display validation errors
        }

    }
}