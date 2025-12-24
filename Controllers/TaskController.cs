using DailyTaskReminderSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyTaskReminderSystem.Models;
using Microsoft.Identity.Client;
namespace DailyTaskReminderSystem.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult MyTasks()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var tasks = _context.TaskModels.Where(t=>t.UserId==userId).ToList();
            return View(tasks);
        }
        public IActionResult Create() => View();//goes  to task.cshtml
        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            task.UserId = userId.Value;
            task.IsCompleted = false;
            task.IsReminderActive = task.ReminderTime!=null;//reminder active only if time is set

            _context.TaskModels.Add(task);
            _context.SaveChanges();

            return RedirectToAction("MyTasks");
        }

    }
}
