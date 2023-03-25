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
    public class Attributes_TableAttributesController : ControllerBase
    {
        private readonly StorageDbContext _context;

        public Attributes_TableAttributesController(StorageDbContext context)
        {
            _context = context;
        }

        // GET: api/Attributes_TableAttributes
        [EnableCors("Policy1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attributes_TableAttribute>>> GetAttributes_TableAttributes()
        {
          if (_context.Attributes_TableAttributes == null)
          {
              return NotFound();
          }
            return await _context.Attributes_TableAttributes.ToListAsync();
        }

        // GET: api/Attributes_TableAttributes/5
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Attributes_TableAttribute>> GetAttributes_TableAttribute(int id)
        {
          if (_context.Attributes_TableAttributes == null)
          {
              return NotFound();
          }
            var attributes_TableAttribute = await _context.Attributes_TableAttributes.FindAsync(id);

            if (attributes_TableAttribute == null)
            {
                return NotFound();
            }

            return attributes_TableAttribute;
        }

        // PUT: api/Attributes_TableAttributes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributes_TableAttribute(int id, Attributes_TableAttribute attributes_TableAttribute)
        {
            if (id != attributes_TableAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(attributes_TableAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Attributes_TableAttributeExists(id))
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

        // POST: api/Attributes_TableAttributes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("Policy1")]
        [HttpPost]
        public async Task<ActionResult<Attributes_TableAttribute>> PostAttributes_TableAttribute(Attributes_TableAttribute attributes_TableAttribute)
        {
          if (_context.Attributes_TableAttributes == null)
          {
              return Problem("Entity set 'StorageDbContext.Attributes_TableAttributes'  is null.");
          }
            _context.Attributes_TableAttributes.Add(attributes_TableAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttributes_TableAttribute), new { id = attributes_TableAttribute.Id }, attributes_TableAttribute);
        }

        // DELETE: api/Attributes_TableAttributes/5
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttributes_TableAttribute(int id)
        {
            if (_context.Attributes_TableAttributes == null)
            {
                return NotFound();
            }
            var attributes_TableAttribute = await _context.Attributes_TableAttributes.FindAsync(id);
            if (attributes_TableAttribute == null)
            {
                return NotFound();
            }

            _context.Attributes_TableAttributes.Remove(attributes_TableAttribute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Attributes_TableAttributeExists(int id)
        {
            return (_context.Attributes_TableAttributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
