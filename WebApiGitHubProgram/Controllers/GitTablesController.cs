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
    public class GitTablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public GitTablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/GitTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitTable>>> GetGitTable()
        {
            return await _context.GitTable.ToListAsync();
        }

        // GET: api/GitTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GitTable>> GetGitTable(int id)
        {
            var gitTable = await _context.GitTable.FindAsync(id);

            if (gitTable == null)
            {
                return NotFound();
            }

            return gitTable;
        }

        // PUT: api/GitTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGitTable(int id, GitTable gitTable)
        {
            if (id != gitTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(gitTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GitTableExists(id))
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

        // POST: api/GitTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GitTable>> PostGitTable(GitTable gitTable)
        {
            _context.GitTable.Add(gitTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGitTable", new { id = gitTable.Id }, gitTable);
        }

        // DELETE: api/GitTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GitTable>> DeleteGitTable(int id)
        {
            var gitTable = await _context.GitTable.FindAsync(id);
            if (gitTable == null)
            {
                return NotFound();
            }

            _context.GitTable.Remove(gitTable);
            await _context.SaveChangesAsync();

            return gitTable;
        }

        private bool GitTableExists(int id)
        {
            return _context.GitTable.Any(e => e.Id == id);
        }
    }
}
