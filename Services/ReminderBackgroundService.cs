using DailyTaskReminderSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskReminderSystem.Services
{
    public class ReminderBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ReminderBackgroundService> _logger;

        public ReminderBackgroundService(
     IServiceScopeFactory scopeFactory,
     ILogger<ReminderBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var now = DateTime.Now;
                _logger.LogInformation("⏰ Background check at {time}", now);

                var candidateTasks = context.TaskModels
                    .Where(t =>
                        t.IsReminderActive &&
                        !t.IsCompleted &&
                        t.ReminderTime.HasValue)
                    .ToList();

                foreach (var task in candidateTasks)
                {
                    _logger.LogInformation(
                        "📌 Task: {title}, ReminderTime: {time}",
                        task.Title,
                        task.ReminderTime);
                }

                var dueTasks = candidateTasks
                    .Where(t =>
                        t.ReminderTime.Value >= now.AddMinutes(-1) &&
                        t.ReminderTime.Value <= now.AddMinutes(1))
                    .ToList();

                foreach (var task in dueTasks)
                {
                    _logger.LogInformation("🔔 REMINDER TRIGGERED: {title}", task.Title);
                    task.IsReminderActive = false;
                }

                context.SaveChanges();

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }



    }
}
