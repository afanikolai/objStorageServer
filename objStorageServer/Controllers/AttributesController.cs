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
    public class AttributesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public AttributesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/Attributes
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Attribute>>> GetAttributes()
        {
          if (_context.Attributes == null)
          {
              return NotFound();
          }
            return await _context.Attributes.ToListAsync();
        }

        // GET: api/Attributes/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Attribute>> GetAttribute(int id)
        {
          if (_context.Attributes == null)
          {
              return NotFound();
          }
            var attribute = await _context.Attributes.FindAsync(id);

            if (attribute == null)
            {
                return NotFound();
            }

            return attribute;
        }

        // PUT: api/Attributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute(int id, Models.Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(attribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeExists(id))
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

        // POST: api/Attributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<Models.Attribute>> PostAttribute(Models.Attribute attribute)
        {
          if (_context.Attributes == null)
          {
              return Problem("Entity set 'StorageDbContext.Attributes'  is null.");
          }
            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttribute), new { id = attribute.Id }, attribute);
        }

        // DELETE: api/Attributes/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            if (_context.Attributes == null)
            {
                return NotFound();
            }
            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttributeExists(int id)
        {
            return (_context.Attributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
