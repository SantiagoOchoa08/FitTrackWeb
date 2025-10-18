using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutinasController : ControllerBase
    {
        // Lista temporal para simular una base de datos
        private static List<Rutina> rutinas = new List<Rutina>
        {
            new Rutina { Id = 1, UsuarioId = 1, Nombre = "Piernas", Descripcion = "Sentadillas, zancadas y peso muerto" },
            new Rutina { Id = 2, UsuarioId = 2, Nombre = "Pecho", Descripcion = "Press banca, flexiones y fondos" }
        };

        // GET: api/rutinas
        [HttpGet]
        public ActionResult<IEnumerable<Rutina>> GetAll()
        {
            return Ok(rutinas);
        }

        // GET: api/rutinas/1
        [HttpGet("{id}")]
        public ActionResult<Rutina> GetById(int id)
        {
            var rutina = rutinas.Find(r => r.Id == id);
            if (rutina == null)
                return NotFound($"No se encontró la rutina con ID {id}");

            return Ok(rutina);
        }

        // POST: api/rutinas
        [HttpPost]
        public ActionResult<Rutina> Create([FromBody] Rutina nuevaRutina)
        {
            nuevaRutina.Id = rutinas.Max(r => r.Id) + 1;
            rutinas.Add(nuevaRutina);
            return CreatedAtAction(nameof(GetById), new { id = nuevaRutina.Id }, nuevaRutina);
        }

        // PUT: api/rutinas/1
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Rutina rutinaActualizada)
        {
            var rutina = rutinas.Find(r => r.Id == id);
            if (rutina == null)
                return NotFound($"No se encontró la rutina con ID {id}");

            rutina.Nombre = rutinaActualizada.Nombre;
            rutina.Descripcion = rutinaActualizada.Descripcion;
            rutina.UsuarioId = rutinaActualizada.UsuarioId;

            return Ok(rutina);
        }

        // DELETE: api/rutinas/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var rutina = rutinas.Find(r => r.Id == id);
            if (rutina == null)
                return NotFound($"No se encontró la rutina con ID {id}");

            rutinas.Remove(rutina);
            return NoContent();
        }
    }

    // Clase modelo
    public class Rutina
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
