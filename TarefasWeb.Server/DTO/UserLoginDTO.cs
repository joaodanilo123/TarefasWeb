namespace TarefasWeb.DTO
{
    public record UserLoginDTO
    {
        public required string Username { get; init; }

        public required string Password { get; init; }
    }
}

