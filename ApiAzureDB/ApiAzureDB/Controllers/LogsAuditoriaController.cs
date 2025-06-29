using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAzureDB.Data;
//using ApiAzureDB.Models;

namespace ApiAzureDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsAuditoriaController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public LogsAuditoriaController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAuditoria>>> Get()
        {
            return await _context.LogsAuditoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogAuditoria>> Get(int id)
        {
            var log = await _context.LogsAuditoria.FindAsync(id);
            return log == null ? NotFound() : Ok(log);
        }

        [HttpPost]
        public async Task<ActionResult<LogAuditoria>> Post(LogAuditoria log)
        {
            _context.LogsAuditoria.Add(log);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = log.LogID }, log);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var log = await _context.LogsAuditoria.FindAsync(id);
            if (log == null) return NotFound();
            _context.LogsAuditoria.Remove(log);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
