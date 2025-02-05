namespace TarefasWeb.DTO
{
    public record UserDTO
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public required string Username { get; set; }
    }
}

