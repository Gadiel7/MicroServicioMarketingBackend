using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicioMarketingBackend.Modelo;
using Microsoft.Extensions.Logging;
using MicroServicioMarketingBackend.Data;

namespace MicroServicioMarketingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteContext _db;
        private readonly ILogger<EstudianteController> _log;

        public EstudianteController(EstudianteContext db, ILogger<EstudianteController> log)
        {
            _db = db;
            _log = log;
        }

        // GET: api/Estudiante
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.Estudiantes.OrderBy(s => s.Nombre).ToListAsync();
            return Ok(list);
        }

        // LISTAR: api/Estudiante/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _db.Estudiantes.FindAsync(id);
            if (s == null) return NotFound();
            return Ok(s);
        }

        // INSERTAR: api/Estudiante
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudiante estudiante)
        {
            estudiante.FechaActualizacion = DateTime.UtcNow;
            _db.Estudiantes.Add(estudiante);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = estudiante.Id }, estudiante);
        }

        // ACTUALIZAR: api/Estudiante/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Estudiante updated)
        {
            var s = await _db.Estudiantes.FindAsync(id);
            if (s == null) return NotFound();

            s.Nombre = updated.Nombre;
            s.Celular = updated.Celular;
            s.Email = updated.Email;
            s.FechaActualizacion = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // ELIMINAR: api/Estudiante/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _db.Estudiantes.FindAsync(id);
            if (s == null) return NotFound();

            _db.Estudiantes.Remove(s);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
