using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TarefasWeb.DTO;

namespace TarefasWeb.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required TaskStatus Status { get; set; }
        public required DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public required int UserId {  get; set; }
        public required User User { get; set; }

        public TaskDTO ToTaskDTO()
        {
            return new TaskDTO()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Status = Status,
                CompletedAt = CompletedAt,
                CreatedAt = CreatedAt
            };
        }
    }

    public enum TaskStatus
    {
        PENDING,
        IN_PROGRESS,
        COMPLETED
    }

}
