using TarefasWeb.Models;

namespace TarefasWeb.DTO
{
    public record NewUserDTO
    {
        public required string Name { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }
    }
}
