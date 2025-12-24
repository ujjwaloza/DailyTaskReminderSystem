using DailyTaskReminderSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskReminderSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }
    }
}
