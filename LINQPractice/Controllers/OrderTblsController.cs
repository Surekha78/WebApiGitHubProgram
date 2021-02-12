using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LINQPractice;

namespace LINQPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTblsController : ControllerBase
    {
        private readonly DemodbContext _context;

        public OrderTblsController(DemodbContext context)
        {
            _context = context;
        }

        // GET: api/OrderTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderTbl>>> GetOrderTbl()
        {
            return await _context.OrderTbl.ToListAsync();
        }

        // GET: api/OrderTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderTbl>> GetOrderTbl(int id)
        {
            var orderTbl = await _context.OrderTbl.FindAsync(id);

            if (orderTbl == null)
            {
                return NotFound();
            }

            return orderTbl;
        }

        // PUT: api/OrderTbls/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderTbl(int id, OrderTbl orderTbl)
        {
            if (id != orderTbl.Oid)
            {
                return BadRequest();
            }

            _context.Entry(orderTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTblExists(id))
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

        // POST: api/OrderTbls
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderTbl>> PostOrderTbl(OrderTbl orderTbl)
        {
            _context.OrderTbl.Add(orderTbl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderTblExists(orderTbl.Oid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderTbl", new { id = orderTbl.Oid }, orderTbl);
        }

        // DELETE: api/OrderTbls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderTbl>> DeleteOrderTbl(int id)
        {
            var orderTbl = await _context.OrderTbl.FindAsync(id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            _context.OrderTbl.Remove(orderTbl);
            await _context.SaveChangesAsync();

            return orderTbl;
        }

        private bool OrderTblExists(int id)
        {
            return _context.OrderTbl.Any(e => e.Oid == id);
        }
    }
}
