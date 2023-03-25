using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using objStorageServer.Models;

namespace objStorageServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentSettingsController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public DocumentSettingsController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentSettings
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentSetting>>> GetDocumentSettings()
        {
          if (_context.DocumentSettings == null)
          {
              return NotFound();
          }
            return await _context.DocumentSettings.ToListAsync();
        }

        // GET: api/DocumentSettings/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentSetting>> GetDocumentSetting(int id)
        {
          if (_context.DocumentSettings == null)
          {
              return NotFound();
          }
            var documentSetting = await _context.DocumentSettings.FindAsync(id);

            if (documentSetting == null)
            {
                return NotFound();
            }

            return documentSetting;
        }

        // PUT: api/DocumentSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentSetting(int id, DocumentSetting documentSetting)
        {
            if (id != documentSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentSettingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DocumentSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<DocumentSetting>> PostDocumentSetting(DocumentSetting documentSetting)
        {
          if (_context.DocumentSettings == null)
          {
              return Problem("Entity set 'StorageDbContext.DocumentSettings'  is null.");
          }
            _context.DocumentSettings.Add(documentSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumentSetting), new { id = documentSetting.Id }, documentSetting);
        }

        // DELETE: api/DocumentSettings/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentSetting(int id)
        {
            if (_context.DocumentSettings == null)
            {
                return NotFound();
            }
            var documentSetting = await _context.DocumentSettings.FindAsync(id);
            if (documentSetting == null)
            {
                return NotFound();
            }

            _context.DocumentSettings.Remove(documentSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentSettingExists(int id)
        {
            return (_context.DocumentSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
