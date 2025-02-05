namespace TarefasWeb.DTO
{
    public record TaskDTO
    {
        public int? Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public Models.TaskStatus? Status { get; init; }
        public DateTime? CreatedAt { get; init; }
        public DateTime? CompletedAt { get; init; }
    }
}
