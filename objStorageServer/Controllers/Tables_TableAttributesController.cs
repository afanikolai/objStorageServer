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
    public class Tables_TableAttributesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public Tables_TableAttributesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/Tables_TableAttributes
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tables_TableAttribute>>> GetTables_TableAttributes()
        {
          if (_context.Tables_TableAttributes == null)
          {
              return NotFound();
          }
            return await _context.Tables_TableAttributes.ToListAsync();
        }

        // GET: api/Tables_TableAttributes/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Tables_TableAttribute>> GetTables_TableAttribute(int id)
        {
          if (_context.Tables_TableAttributes == null)
          {
              return NotFound();
          }
            var tables_TableAttribute = await _context.Tables_TableAttributes.FindAsync(id);

            if (tables_TableAttribute == null)
            {
                return NotFound();
            }

            return tables_TableAttribute;
        }

        // PUT: api/Tables_TableAttributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTables_TableAttribute(int id, Tables_TableAttribute tables_TableAttribute)
        {
            if (id != tables_TableAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(tables_TableAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tables_TableAttributeExists(id))
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

        // POST: api/Tables_TableAttributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<Tables_TableAttribute>> PostTables_TableAttribute(Tables_TableAttribute tables_TableAttribute)
        {
          if (_context.Tables_TableAttributes == null)
          {
              return Problem("Entity set 'StorageDbContext.Tables_TableAttributes'  is null.");
          }
            _context.Tables_TableAttributes.Add(tables_TableAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTables_TableAttribute), new { id = tables_TableAttribute.Id }, tables_TableAttribute);
        }

        // DELETE: api/Tables_TableAttributes/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTables_TableAttribute(int id)
        {
            if (_context.Tables_TableAttributes == null)
            {
                return NotFound();
            }
            var tables_TableAttribute = await _context.Tables_TableAttributes.FindAsync(id);
            if (tables_TableAttribute == null)
            {
                return NotFound();
            }

            _context.Tables_TableAttributes.Remove(tables_TableAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tables_TableAttributeExists(int id)
        {
            return (_context.Tables_TableAttributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
