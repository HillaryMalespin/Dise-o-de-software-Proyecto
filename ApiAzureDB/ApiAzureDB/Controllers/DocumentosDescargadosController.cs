using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosDescargadosController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public DocumentosDescargadosController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoDescargado>>> Get()
        {
            return await _context.DocumentosDescargados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoDescargado>> Get(int id)
        {
            var descarga = await _context.DocumentosDescargados.FindAsync(id);
            return descarga == null ? NotFound() : Ok(descarga);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoDescargado>> Post(DocumentoDescargado descarga)
        {
            _context.DocumentosDescargados.Add(descarga);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = descarga.DescargaID }, descarga);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var descarga = await _context.DocumentosDescargados.FindAsync(id);
            if (descarga == null) return NotFound();
            _context.DocumentosDescargados.Remove(descarga);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
