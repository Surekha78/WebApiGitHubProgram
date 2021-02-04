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
    public class MyDatasController : ControllerBase
    {
        private readonly WebApiGitHubProgramContext _context;

        public MyDatasController(WebApiGitHubProgramContext context)
        {
            _context = context;
        }

        // GET: api/MyDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyData>>> GetMyData()
        {
            return await _context.MyData.ToListAsync();
        }

        // GET: api/MyDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyData>> GetMyData(int id)
        {
            var myData = await _context.MyData.FindAsync(id);

            if (myData == null)
            {
                return NotFound();
            }

            return myData;
        }

        // PUT: api/MyDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyData(int id, MyData myData)
        {
            if (id != myData.Id)
            {
                return BadRequest();
            }

            _context.Entry(myData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyDataExists(id))
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

        // POST: api/MyDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyData>> PostMyData(MyData myData)
        {
            _context.MyData.Add(myData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyData", new { id = myData.Id }, myData);
        }

        // DELETE: api/MyDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyData>> DeleteMyData(int id)
        {
            var myData = await _context.MyData.FindAsync(id);
            if (myData == null)
            {
                return NotFound();
            }

            _context.MyData.Remove(myData);
            await _context.SaveChangesAsync();

            return myData;
        }

        private bool MyDataExists(int id)
        {
            return _context.MyData.Any(e => e.Id == id);
        }
    }
}
