using Microsoft.AspNetCore.Mvc;
using TarefasWeb.DTO;
using TarefasWeb.Models;

namespace TarefasWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {

        [HttpGet]
        public IActionResult ListarTarefas()
        {
            return Ok(Tarefa.tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarTarefaPorId(int id) {

            Tarefa? tarefa = Tarefa.tarefas.Find(t => t.Id == id);

            if (tarefa == null) 
            {
                return NotFound();
            }

            return Ok(tarefa.ToTarefaDTO());
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarTarefa([FromBody] TarefaDTO dto)
        {

            int id;

            if (Tarefa.tarefas.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = Tarefa.tarefas.Last().Id + 1;
            }

            Tarefa novaTarefa = new Tarefa()
            {
                Id = id,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = TarefaStatus.PENDENTE,
                CriadaEm = DateTime.Now,
            };

            Tarefa.tarefas.Add(novaTarefa);

            return Ok("Tarefa cadastrada com sucesso");
        }

        [HttpPost("{id}/concluir")]
        public IActionResult ConcluirTarefa(int id)
        {

            Tarefa? tarefa = Tarefa.tarefas.Find(t => t.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.ConcluidaEm = DateTime.Now;

            return Ok("Tarefa marcada como concluída");
        }

        [HttpPost("{id}/excluir")]
        public IActionResult ExcluirTarefa(int id)
        {

            Tarefa? tarefa = Tarefa.tarefas.Find(t => t.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            Tarefa.tarefas.Remove(tarefa);

            return Ok("Tarefa excluída com sucesso");
        }
    }
}