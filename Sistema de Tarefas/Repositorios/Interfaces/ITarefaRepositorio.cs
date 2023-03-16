using Sistema_de_Tarefas.Models;

namespace Sistema_de_Tarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<Tarefa>> BuscarTarefas();
        Task<Tarefa> BuscarPorId(int id);
        Task<Tarefa> Adcionar(Tarefa usuarioTarefa);
        Task<Tarefa> Actualizar(Tarefa usuario, int id);
        Task<bool> Apagar(int id);
    }
}
