using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoCategoriasController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public DocumentoCategoriasController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoCategoria>>> Get()
        {
            return await _context.DocumentoCategorias.ToListAsync();
        }

        [HttpGet("{documentoId}/{categoriaId}")]
        public async Task<ActionResult<DocumentoCategoria>> Get(int documentoId, int categoriaId)
        {
            var item = await _context.DocumentoCategorias
                .FirstOrDefaultAsync(dc => dc.DocumentoID == documentoId && dc.CategoriaID == categoriaId);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoCategoria>> Post(DocumentoCategoria item)
        {
            _context.DocumentoCategorias.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { documentoId = item.DocumentoID, categoriaId = item.CategoriaID }, item);
        }

        [HttpDelete("{documentoId}/{categoriaId}")]
        public async Task<IActionResult> Delete(int documentoId, int categoriaId)
        {
            var item = await _context.DocumentoCategorias
                .FirstOrDefaultAsync(dc => dc.DocumentoID == documentoId && dc.CategoriaID == categoriaId);

            if (item == null) return NotFound();

            _context.DocumentoCategorias.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
