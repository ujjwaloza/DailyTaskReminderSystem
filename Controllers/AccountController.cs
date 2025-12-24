
using DailyTaskReminderSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DailyTaskReminderSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
            public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login() => View();// view return login.cshtml

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "InvalidCredeantials";
                return View();


            }
            HttpContext.Session.SetInt32("UserId", user.UserId);
            return RedirectToAction("MyTasks", "Task");
        }
        
    }
}
