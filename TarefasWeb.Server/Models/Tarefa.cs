using TarefasWeb.DTO;

namespace TarefasWeb.Models
{
    public class Tarefa
    {

        public static List<Tarefa> tarefas = new List<Tarefa>();

        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public required TarefaStatus Status { get; set; }
        public required DateTime? CriadaEm { get; set; }
        public DateTime? ConcluidaEm { get; set; }

        public TarefaDTO ToTarefaDTO()
        {
            return new TarefaDTO()
            {
                Id = Id,
                Titulo = Titulo,
                Descricao = Descricao,
                Status = Status,
                ConcluidaEm = ConcluidaEm,
                CriadaEm = CriadaEm
            };
        }
    }

    public enum TarefaStatus
    {
        PENDENTE,
        ANDAMENTO,
        CONCLUIDA
    }

}
