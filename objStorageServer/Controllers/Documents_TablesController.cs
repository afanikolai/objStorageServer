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
    public class Documents_TablesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public Documents_TablesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/Documents_Tables
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documents_Table>>> GetDocuments_Tables()
        {
          if (_context.Documents_Tables == null)
          {
              return NotFound();
          }
            return await _context.Documents_Tables.ToListAsync();
        }

        // GET: api/Documents_Tables/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Documents_Table>> GetDocuments_Table(int id)
        {
          if (_context.Documents_Tables == null)
          {
              return NotFound();
          }
            var documents_Table = await _context.Documents_Tables.FindAsync(id);

            if (documents_Table == null)
            {
                return NotFound();
            }

            return documents_Table;
        }

        // PUT: api/Documents_Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocuments_Table(int id, Documents_Table documents_Table)
        {
            if (id != documents_Table.Id)
            {
                return BadRequest();
            }

            _context.Entry(documents_Table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Documents_TableExists(id))
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

        // POST: api/Documents_Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<Documents_Table>> PostDocuments_Table(Documents_Table documents_Table)
        {
          if (_context.Documents_Tables == null)
          {
              return Problem("Entity set 'StorageDbContext.Documents_Tables'  is null.");
          }
            _context.Documents_Tables.Add(documents_Table);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocuments_Table), new { id = documents_Table.Id }, documents_Table);
        }

        // DELETE: api/Documents_Tables/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocuments_Table(int id)
        {
            if (_context.Documents_Tables == null)
            {
                return NotFound();
            }
            var documents_Table = await _context.Documents_Tables.FindAsync(id);
            if (documents_Table == null)
            {
                return NotFound();
            }

            _context.Documents_Tables.Remove(documents_Table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Documents_TableExists(int id)
        {
            return (_context.Documents_Tables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
