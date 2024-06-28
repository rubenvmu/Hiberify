using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

namespace webmusic_solved.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirasController : ControllerBase
    {
        private readonly GrupoAContext _context;

        public GirasController(GrupoAContext context)
        {
            _context = context;
        }

        // GET: api/Giras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giras>>> GetGiras()
        {
            return await _context.Giras.ToListAsync();
        }

        // GET: api/Giras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giras>> GetGiras(int id)
        {
            var giras = await _context.Giras.FindAsync(id);

            if (giras == null)
            {
                return NotFound();
            }

            return giras;
        }

        // PUT: api/Giras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiras(int id, Giras giras)
        {
            if (id != giras.Id)
            {
                return BadRequest();
            }

            _context.Entry(giras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GirasExists(id))
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

        // POST: api/Giras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giras>> PostGiras(Giras giras)
        {
            _context.Giras.Add(giras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiras", new { id = giras.Id }, giras);
        }

        // DELETE: api/Giras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiras(int id)
        {
            var giras = await _context.Giras.FindAsync(id);
            if (giras == null)
            {
                return NotFound();
            }

            _context.Giras.Remove(giras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GirasExists(int id)
        {
            return _context.Giras.Any(e => e.Id == id);
        }
    }
}
