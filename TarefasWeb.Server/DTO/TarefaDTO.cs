using TarefasWeb.Models;

namespace TarefasWeb.DTO
{
    public record TarefaDTO
    {
        public int? Id { get; init; }
        public required string Titulo { get; init; }
        public string? Descricao { get; init; }
        public TarefaStatus? Status { get; init; }
        public DateTime? CriadaEm { get; init; }
        public DateTime? ConcluidaEm { get; init; }
    }
}
