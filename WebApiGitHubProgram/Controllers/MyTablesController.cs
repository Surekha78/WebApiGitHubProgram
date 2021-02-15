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
    // [Route("api/[controller]")]
    [ApiController]
    public class MyTablesController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public MyTablesController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/MyTables
        [Route("api/GetMyTable")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTable>>> GetMyTable()
        {
            return await _context.MyTables.ToListAsync();
        }

        // GET: api/MyTables/5
        [Route("api/GetMyTableByPK")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTable>> GetMyTable(int id)
        {
            var myTable = await _context.MyTables.FindAsync(id);

            if (myTable == null)
            {
                return NotFound();
            }

            return myTable;
        }

        // PUT: api/MyTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("api/PutMyTable")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTable(int id, MyTable myTable)
        {
            if (id != myTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(myTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTableExists(id))
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

        // POST: api/MyTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("api/POSTMyTable")]
        [HttpPost]
        public async Task<int> PostMyTable([FromBody] MyTable myTable)
        {
            _context.MyTables.Add(myTable);
            await _context.SaveChangesAsync();

            return myTable.Id;
        }

        [Route("api/MyTableMulti")]
        [HttpPost]
        public async Task<ActionResult> PostMyTable([FromBody] List<MyTable> myTables)
        {
            _context.MyTables.AddRange(myTables);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/MyTables/5
        [Route("api/DeleteMyTable")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyTable>> DeleteMyTable(int id)
        {
            var myTable = await _context.MyTables.FindAsync(id);
            if (myTable == null)
            {
                return NotFound();
            }

            _context.MyTables.Remove(myTable);
            await _context.SaveChangesAsync();

            return myTable;
        }

        private bool MyTableExists(int id)
        {
            return _context.MyTables.Any(e => e.Id == id);
        }
    }
}
