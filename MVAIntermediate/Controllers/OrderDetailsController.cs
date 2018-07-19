﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVAIntermediate.Data;
using MVAIntermediate.Models;

namespace MVAIntermediate.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderDetails")]
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetails = await _context.OrderDetails.SingleOrDefaultAsync(m => m.OrderDetailNo == id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }

        // GET: api/OrderDetails/5
        [HttpGet]
        [Route("ByOrderNo/{orderNo}")]
        public async Task<IActionResult> GetOrderDetailsByOrderNo([FromRoute] int orderNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetails = await (_context.OrderDetails.Where(s => s.OrderNo == orderNo).ToListAsync<OrderDetails>());

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetails([FromRoute] int id, [FromBody] OrderDetails orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetails.OrderDetailNo)
            {
                return BadRequest();
            }

            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(id))
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

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<IActionResult> PostOrderDetails([FromBody] OrderDetails orderDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetails", new { id = orderDetails.OrderDetailNo }, orderDetails);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetails = await _context.OrderDetails.SingleOrDefaultAsync(m => m.OrderDetailNo == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();

            return Ok(orderDetails);
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailNo == id);
        }
    }
}