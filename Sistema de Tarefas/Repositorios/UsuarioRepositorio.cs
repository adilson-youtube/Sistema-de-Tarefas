using Microsoft.EntityFrameworkCore;
using Sistema_de_Tarefas.Data;
using Sistema_de_Tarefas.Models;
using Sistema_de_Tarefas.Repositorios.Interfaces;

namespace Sistema_de_Tarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dBContex;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex) 
        {
            _dBContex = sistemaTarefasDBContex;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dBContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarUsuarios()
        {
            return await _dBContex.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Adcionar(Usuario usuario)
        {
            await _dBContex.Usuarios.AddAsync(usuario);
            await _dBContex.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Actualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null) 
            {
                throw new Exception($"Usuário com o ID: {id} não foi encontrado no BD");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dBContex.Usuarios.Update(usuarioPorId);
            await _dBContex.SaveChangesAsync();

            return usuarioPorId;
            
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com o ID: {id} não foi encontrado no BD");
            }

            _dBContex.Usuarios.Remove(usuarioPorId);
            await _dBContex.SaveChangesAsync();
            return true;

        }
    }
}
