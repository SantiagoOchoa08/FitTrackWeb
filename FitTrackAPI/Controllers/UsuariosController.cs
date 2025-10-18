using Microsoft.AspNetCore.Mvc;
using FitTrackAPI.Models;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Juan", Correo = "juan@mail.com", Edad = 25, Genero = "Masculino", Peso = 70, Altura = 1.75 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetAll() => Ok(usuarios);

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario nuevoUsuario)
        {
            nuevoUsuario.Id = usuarios.Count + 1;
            usuarios.Add(nuevoUsuario);
            return CreatedAtAction(nameof(GetById), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Edad = usuarioActualizado.Edad;
            usuario.Genero = usuarioActualizado.Genero;
            usuario.Peso = usuarioActualizado.Peso;
            usuario.Altura = usuarioActualizado.Altura;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();

            usuarios.Remove(usuario);
            return NoContent();
        }
    }
}
