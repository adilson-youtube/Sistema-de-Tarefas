using Microsoft.EntityFrameworkCore;
using Sistema_de_Tarefas.Data;
using Sistema_de_Tarefas.Models;
using Sistema_de_Tarefas.Repositorios.Interfaces;

namespace Sistema_de_Tarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContex _dBContex;
        public TarefaRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex) 
        {
            _dBContex = sistemaTarefasDBContex;
        }

        public async Task<Tarefa> BuscarPorId(int id)
        {
            return await _dBContex.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tarefa>> BuscarTarefas()
        {
            return await _dBContex.Tarefas.Include(x => x.Usuario).ToListAsync();
        }

        public async Task<Tarefa> Adcionar(Tarefa tarefa)
        {
            await _dBContex.Tarefas.AddAsync(tarefa);
            await _dBContex.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> Actualizar(Tarefa tarefa, int id)
        {
            Tarefa tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null) 
            {
                throw new Exception($"Tarefa com o ID: {id} não foi encontrado no BD");
            }

            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;
            //tarefaPorId.Usuario = tarefa.Usuario;

            _dBContex.Tarefas.Update(tarefaPorId);
            await _dBContex.SaveChangesAsync();

            return tarefaPorId;
            
        }

        public async Task<bool> Apagar(int id)
        {
            Tarefa tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi encontrado no BD");
            }

            _dBContex.Tarefas.Remove(tarefaPorId);
            await _dBContex.SaveChangesAsync();
            return true;

        }
    }
}
