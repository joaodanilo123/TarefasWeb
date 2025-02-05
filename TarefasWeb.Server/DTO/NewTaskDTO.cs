using TarefasWeb.Models;

namespace TarefasWeb.DTO
{
    public record NewTaskDTO
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
    }
}
