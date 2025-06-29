using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public DocumentosController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> Get()
        {
            return await _context.Documentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> Get(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            return documento == null ? NotFound() : Ok(documento);
        }

        [HttpPost]
        public async Task<ActionResult<Documento>> Post(Documento documento)
        {
            _context.Documentos.Add(documento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = documento.DocumentoID }, documento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Documento documento)
        {
            if (id != documento.DocumentoID) return BadRequest();
            _context.Entry(documento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null) return NotFound();
            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
