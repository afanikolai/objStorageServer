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
    public class DocumentFilesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public DocumentFilesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentFiles
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentFile>>> GetDocumentFiles()
        {
          if (_context.DocumentFiles == null)
          {
              return NotFound();
          }
            return await _context.DocumentFiles.ToListAsync();
        }

        // GET: api/DocumentFiles/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentFile>> GetDocumentFile(int id)
        {
          if (_context.DocumentFiles == null)
          {
              return NotFound();
          }
            var documentFile = await _context.DocumentFiles.FindAsync(id);

            if (documentFile == null)
            {
                return NotFound();
            }

            return documentFile;
        }

        // PUT: api/DocumentFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentFile(int id, DocumentFile documentFile)
        {
            if (id != documentFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentFileExists(id))
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

        // POST: api/DocumentFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<DocumentFile>> PostDocumentFile(DocumentFile documentFile)
        {
          if (_context.DocumentFiles == null)
          {
              return Problem("Entity set 'StorageDbContext.DocumentFiles'  is null.");
          }
            _context.DocumentFiles.Add(documentFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumentFile), new { id = documentFile.Id }, documentFile);
        }

        // DELETE: api/DocumentFiles/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentFile(int id)
        {
            if (_context.DocumentFiles == null)
            {
                return NotFound();
            }
            var documentFile = await _context.DocumentFiles.FindAsync(id);
            if (documentFile == null)
            {
                return NotFound();
            }

            _context.DocumentFiles.Remove(documentFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentFileExists(int id)
        {
            return (_context.DocumentFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
