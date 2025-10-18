using Microsoft.AspNetCore.Mvc;
using FitTrackAPI.Models;

namespace FitTrackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjerciciosController : ControllerBase
    {
        private static List<Ejercicio> ejercicios = new List<Ejercicio>
        {
            new Ejercicio { Id = 1, Nombre = "Flexiones", GrupoMuscular = "Pectorales", Descripcion = "Flexiones de pecho clásicas", DuracionSegundos = 60, CaloriasEstimadas = 15 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Ejercicio>> GetAll() => Ok(ejercicios);

        [HttpGet("{id}")]
        public ActionResult<Ejercicio> GetById(int id)
        {
            var ejercicio = ejercicios.FirstOrDefault(e => e.Id == id);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [HttpPost]
        public ActionResult<Ejercicio> Create(Ejercicio nuevoEjercicio)
        {
            nuevoEjercicio.Id = ejercicios.Count + 1;
            ejercicios.Add(nuevoEjercicio);
            return CreatedAtAction(nameof(GetById), new { id = nuevoEjercicio.Id }, nuevoEjercicio);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ejercicio ejercicioActualizado)
        {
            var ejercicio = ejercicios.FirstOrDefault(e => e.Id == id);
            if (ejercicio == null) return NotFound();

            ejercicio.Nombre = ejercicioActualizado.Nombre;
            ejercicio.GrupoMuscular = ejercicioActualizado.GrupoMuscular;
            ejercicio.Descripcion = ejercicioActualizado.Descripcion;
            ejercicio.DuracionSegundos = ejercicioActualizado.DuracionSegundos;
            ejercicio.CaloriasEstimadas = ejercicioActualizado.CaloriasEstimadas;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ejercicio = ejercicios.FirstOrDefault(e => e.Id == id);
            if (ejercicio == null) return NotFound();

            ejercicios.Remove(ejercicio);
            return NoContent();
        }
    }
}
