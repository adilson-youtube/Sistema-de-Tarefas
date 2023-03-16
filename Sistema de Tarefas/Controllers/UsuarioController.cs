using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Tarefas.Models;
using Sistema_de_Tarefas.Repositorios.Interfaces;

namespace Sistema_de_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepositorio.BuscarUsuarios(); 
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarPorId(id); 
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioRequest)
        {
            Usuario usuarioResponse = await _usuarioRepositorio.Adcionar(usuarioRequest);
            return Ok(usuarioResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Actualizar([FromBody] Usuario usuarioRequest, int id)
        {
            usuarioRequest.Id = id;
            Usuario usuarioResponse = await _usuarioRepositorio.Actualizar(usuarioRequest, id);
            return Ok(usuarioResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<Usuario>> Apagar(int id)
        {
            bool response = await _usuarioRepositorio.Apagar(id);
            return Ok(response);
        }
    }
}
