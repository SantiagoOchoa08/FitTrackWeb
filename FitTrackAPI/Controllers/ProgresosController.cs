using Microsoft.AspNetCore.Mvc;
using FitTrackAPI.Models;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgresosController : ControllerBase
    {
        private static List<Progreso> progresos = new List<Progreso>
        {
            new Progreso { Id = 1, UsuarioId = 1, Fecha = DateTime.Now, PesoActual = 70, IMC = 22.9, Observaciones = "Buen progreso" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Progreso>> GetAll() => Ok(progresos);

        [HttpGet("{id}")]
        public ActionResult<Progreso> GetById(int id)
        {
            var progreso = progresos.FirstOrDefault(p => p.Id == id);
            if (progreso == null) return NotFound();
            return Ok(progreso);
        }

        [HttpPost]
        public ActionResult<Progreso> Create(Progreso nuevoProgreso)
        {
            nuevoProgreso.Id = progresos.Count + 1;
            progresos.Add(nuevoProgreso);
            return CreatedAtAction(nameof(GetById), new { id = nuevoProgreso.Id }, nuevoProgreso);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Progreso progresoActualizado)
        {
            var progreso = progresos.FirstOrDefault(p => p.Id == id);
            if (progreso == null) return NotFound();

            progreso.UsuarioId = progresoActualizado.UsuarioId;
            progreso.Fecha = progresoActualizado.Fecha;
            progreso.PesoActual = progresoActualizado.PesoActual;
            progreso.IMC = progresoActualizado.IMC;
            progreso.Observaciones = progresoActualizado.Observaciones;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var progreso = progresos.FirstOrDefault(p => p.Id == id);
            if (progreso == null) return NotFound();

            progresos.Remove(progreso);
            return NoContent();
        }
    }
}
