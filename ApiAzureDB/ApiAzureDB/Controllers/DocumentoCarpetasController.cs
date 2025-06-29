using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoCarpetasController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public DocumentoCarpetasController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoCarpeta>>> Get()
        {
            return await _context.DocumentoCarpetas.ToListAsync();
        }

        [HttpGet("{documentoId}/{carpetaId}")]
        public async Task<ActionResult<DocumentoCarpeta>> Get(int documentoId, int carpetaId)
        {
            var item = await _context.DocumentoCarpetas
                .FirstOrDefaultAsync(dc => dc.DocumentoID == documentoId && dc.CarpetaID == carpetaId);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoCarpeta>> Post(DocumentoCarpeta item)
        {
            _context.DocumentoCarpetas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { documentoId = item.DocumentoID, carpetaId = item.CarpetaID }, item);
        }

        [HttpDelete("{documentoId}/{carpetaId}")]
        public async Task<IActionResult> Delete(int documentoId, int carpetaId)
        {
            var item = await _context.DocumentoCarpetas
                .FirstOrDefaultAsync(dc => dc.DocumentoID == documentoId && dc.CarpetaID == carpetaId);

            if (item == null) return NotFound();

            _context.DocumentoCarpetas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
