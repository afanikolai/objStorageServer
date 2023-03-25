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
    public class TablesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public TablesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, Table table)
        {
            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
          if (_context.Tables == null)
          {
              return Problem("Entity set 'StorageDbContext.Tables'  is null.");
          }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTable), new { id = table.Id }, table);
        }

        // DELETE: api/Tables/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            if (_context.Tables == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(int id)
        {
            return (_context.Tables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
