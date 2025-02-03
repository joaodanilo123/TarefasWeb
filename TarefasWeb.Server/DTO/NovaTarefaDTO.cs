using TarefasWeb.Models;

namespace TarefasWeb.DTO
{
    public record NovaTarefaDTO
    {
        public required string Titulo { get; init; }
        public string? Descricao { get; init; }
        public TarefaStatus? Status { get; init; }
    }
}
