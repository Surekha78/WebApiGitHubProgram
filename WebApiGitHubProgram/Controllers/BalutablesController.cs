using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGitHubProgram.Data;

namespace WebApiGitHubProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalutablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public BalutablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/Balutables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Balutable>>> GetBalutable()
        {
            return await _context.Balutable.ToListAsync();
        }

        // GET: api/Balutables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Balutable>> GetBalutable(int id)
        {
            var balutable = await _context.Balutable.FindAsync(id);

            if (balutable == null)
            {
                return NotFound();
            }

            return balutable;
        }

        // PUT: api/Balutables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalutable(int id, Balutable balutable)
        {
            if (id != balutable.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(balutable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalutableExists(id))
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

        // POST: api/Balutables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Balutable>> PostBalutable(Balutable balutable)
        {
            _context.Balutable.Add(balutable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalutable", new { id = balutable.EmpId }, balutable);
        }

        // DELETE: api/Balutables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Balutable>> DeleteBalutable(int id)
        {
            var balutable = await _context.Balutable.FindAsync(id);
            if (balutable == null)
            {
                return NotFound();
            }

            _context.Balutable.Remove(balutable);
            await _context.SaveChangesAsync();

            return balutable;
        }

        private bool BalutableExists(int id)
        {
            return _context.Balutable.Any(e => e.EmpId == id);
        }
    }
}
