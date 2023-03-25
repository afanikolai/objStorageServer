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
    public class DocumentSettings_AttributesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public DocumentSettings_AttributesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/DocumentSettings_Attributes
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentSettings_Attribute>>> GetDocumentSettings_Attributes()
        {
          if (_context.DocumentSettings_Attributes == null)
          {
              return NotFound();
          }
            return await _context.DocumentSettings_Attributes.ToListAsync();
        }

        // GET: api/DocumentSettings_Attributes/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentSettings_Attribute>> GetDocumentSettings_Attribute(int id)
        {
          if (_context.DocumentSettings_Attributes == null)
          {
              return NotFound();
          }
            var documentSettings_Attribute = await _context.DocumentSettings_Attributes.FindAsync(id);

            if (documentSettings_Attribute == null)
            {
                return NotFound();
            }

            return documentSettings_Attribute;
        }

        // PUT: api/DocumentSettings_Attributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentSettings_Attribute(int id, DocumentSettings_Attribute documentSettings_Attribute)
        {
            if (id != documentSettings_Attribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentSettings_Attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentSettings_AttributeExists(id))
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

        // POST: api/DocumentSettings_Attributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<DocumentSettings_Attribute>> PostDocumentSettings_Attribute(DocumentSettings_Attribute documentSettings_Attribute)
        {
          if (_context.DocumentSettings_Attributes == null)
          {
              return Problem("Entity set 'StorageDbContext.DocumentSettings_Attributes'  is null.");
          }
            _context.DocumentSettings_Attributes.Add(documentSettings_Attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumentSettings_Attribute), new { id = documentSettings_Attribute.Id }, documentSettings_Attribute);
        }

        // DELETE: api/DocumentSettings_Attributes/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentSettings_Attribute(int id)
        {
            if (_context.DocumentSettings_Attributes == null)
            {
                return NotFound();
            }
            var documentSettings_Attribute = await _context.DocumentSettings_Attributes.FindAsync(id);
            if (documentSettings_Attribute == null)
            {
                return NotFound();
            }

            _context.DocumentSettings_Attributes.Remove(documentSettings_Attribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentSettings_AttributeExists(int id)
        {
            return (_context.DocumentSettings_Attributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
