using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Tarefas.Models;
using Sistema_de_Tarefas.Repositorios.Interfaces;

namespace Sistema_de_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio) 
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefa>>> BuscarTodasUsuarios()
        {
            List<Tarefa> tarefas = await _tarefaRepositorio.BuscarTarefas(); 
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> BuscarPorId(int id)
        {
            Tarefa tarefa = await _tarefaRepositorio.BuscarPorId(id); 
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Cadastrar([FromBody] Tarefa tarefaRequest)
        {
            Tarefa tarefaResponse = await _tarefaRepositorio.Adcionar(tarefaRequest);
            return Ok(tarefaResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefa>> Actualizar([FromBody] Tarefa tarefaRequest, int id)
        {
            tarefaRequest.Id = id;
            Tarefa tarefaResponse = await _tarefaRepositorio.Actualizar(tarefaRequest, id);
            return Ok(tarefaResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<Tarefa>> Apagar(int id)
        {
            bool response = await _tarefaRepositorio.Apagar(id);
            return Ok(response);
        }
    }
}
