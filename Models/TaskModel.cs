using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
namespace DailyTaskReminderSystem.Models
{
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? ReminderTime { get; set; }//Time of day
        public bool IsReminderActive { get; set; }//On/Off switch
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
