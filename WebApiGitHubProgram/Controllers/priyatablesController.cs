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
    public class priyatablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public priyatablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/priyatables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<priyatable>>> Getpriyatable()
        {
            return await _context.priyatable.ToListAsync();
        }

        // GET: api/priyatables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<priyatable>> Getpriyatable(int id)
        {
            var priyatable = await _context.priyatable.FindAsync(id);

            if (priyatable == null)
            {
                return NotFound();
            }

            return priyatable;
        }

        // PUT: api/priyatables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpriyatable(int id, priyatable priyatable)
        {
            if (id != priyatable.StudId)
            {
                return BadRequest();
            }

            _context.Entry(priyatable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!priyatableExists(id))
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

        // POST: api/priyatables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<priyatable>> Postpriyatable(priyatable priyatable)
        {
            _context.priyatable.Add(priyatable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpriyatable", new { id = priyatable.StudId }, priyatable);
        }

        // DELETE: api/priyatables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<priyatable>> Deletepriyatable(int id)
        {
            var priyatable = await _context.priyatable.FindAsync(id);
            if (priyatable == null)
            {
                return NotFound();
            }

            _context.priyatable.Remove(priyatable);
            await _context.SaveChangesAsync();

            return priyatable;
        }

        private bool priyatableExists(int id)
        {
            return _context.priyatable.Any(e => e.StudId == id);
        }
    }
}
