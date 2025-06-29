using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public NoticiasController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticiaSummaryDto>>> Get() {
            // Usamos .Select() de LINQ para transformar la entidad completa
            // a nuestro DTO, seleccionando solo los campos que necesitamos.
            var noticiasSummary = await _context.Noticias
                .Select(n => new NoticiaSummaryDto {
                    NoticiaId = n.NoticiaID,
                    Titulo = n.Titulo,
                    ImagenUrl = n.ImagenURL,
                    FechaPublicacion = n.FechaPublicacion
                })
                .ToListAsync();

            return Ok(noticiasSummary);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Noticia>> Get(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            return noticia == null ? NotFound() : Ok(noticia);
        }

        [HttpPost]
        public async Task<ActionResult<Noticia>> Post(Noticia noticia)
        {
            _context.Noticias.Add(noticia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = noticia.NoticiaID }, noticia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Noticia noticia)
        {
            if (id != noticia.NoticiaID) return BadRequest();
            _context.Entry(noticia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null) return NotFound();
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
