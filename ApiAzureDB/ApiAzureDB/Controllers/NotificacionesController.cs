using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public NotificacionesController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacion>>> Get()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacion>> Get(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            return notificacion == null ? NotFound() : Ok(notificacion);
        }

        [HttpPost]
        public async Task<ActionResult<Notificacion>> Post(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = notificacion.NotificacionID }, notificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Notificacion notificacion)
        {
            if (id != notificacion.NotificacionID) return BadRequest();
            _context.Entry(notificacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null) return NotFound();
            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
