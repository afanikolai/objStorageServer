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
    public class TableAttributesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public TableAttributesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/TableAttributes
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableAttribute>>> GetTableAttributes()
        {
          if (_context.TableAttributes == null)
          {
              return NotFound();
          }
            return await _context.TableAttributes.ToListAsync();
        }

        // GET: api/TableAttributes/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TableAttribute>> GetTableAttribute(int id)
        {
          if (_context.TableAttributes == null)
          {
              return NotFound();
          }
            var tableAttribute = await _context.TableAttributes.FindAsync(id);

            if (tableAttribute == null)
            {
                return NotFound();
            }

            return tableAttribute;
        }

        // PUT: api/TableAttributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableAttribute(int id, TableAttribute tableAttribute)
        {
            if (id != tableAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableAttributeExists(id))
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

        // POST: api/TableAttributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<TableAttribute>> PostTableAttribute(TableAttribute tableAttribute)
        {
          if (_context.TableAttributes == null)
          {
              return Problem("Entity set 'StorageDbContext.TableAttributes'  is null.");
          }
            _context.TableAttributes.Add(tableAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTableAttribute), new { id = tableAttribute.Id }, tableAttribute);
        }

        // DELETE: api/TableAttributes/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableAttribute(int id)
        {
            if (_context.TableAttributes == null)
            {
                return NotFound();
            }
            var tableAttribute = await _context.TableAttributes.FindAsync(id);
            if (tableAttribute == null)
            {
                return NotFound();
            }

            _context.TableAttributes.Remove(tableAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableAttributeExists(int id)
        {
            return (_context.TableAttributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
