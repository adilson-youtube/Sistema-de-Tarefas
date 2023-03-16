using Sistema_de_Tarefas.Models;

namespace Sistema_de_Tarefas.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adcionar(Usuario usuario);
        Task<Usuario> Actualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);
    }
}
