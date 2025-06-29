using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarpetasTematicasController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public CarpetasTematicasController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarpetaTematica>>> Get()
        {
            return await _context.CarpetasTematicas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarpetaTematica>> Get(int id)
        {
            var carpeta = await _context.CarpetasTematicas.FindAsync(id);
            return carpeta == null ? NotFound() : Ok(carpeta);
        }

        [HttpPost]
        public async Task<ActionResult<CarpetaTematica>> Post(CarpetaTematica carpeta)
        {
            _context.CarpetasTematicas.Add(carpeta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = carpeta.CarpetaID }, carpeta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CarpetaTematica carpeta)
        {
            if (id != carpeta.CarpetaID) return BadRequest();
            _context.Entry(carpeta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carpeta = await _context.CarpetasTematicas.FindAsync(id);
            if (carpeta == null) return NotFound();
            _context.CarpetasTematicas.Remove(carpeta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
