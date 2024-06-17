using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAspCore.Shared.Context;
using BlazorAspCore.Shared.Entities;
using BlazorAspCore.Shared.Model;

namespace BlazorAspCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingDetailsController : ControllerBase
    {
        private readonly ShoppingDBContext _context;

        public ShoppingDetailsController(ShoppingDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingDetails
        [HttpGet]
        public IEnumerable<myShopping> GetShoppingDetails()
        {
            var results = (from items in _context.ItemDetails
                           join shop in _context.ShoppingDetails
                           on items.ItemId equals shop.ItemId
                           select new myShopping
                           {
                               ShopId = shop.ShopId,
                               ItemName = items.ItemName,
                               ImageName = items.ImageName,
                               UserName = shop.UserName,
                               Qty = shop.Qty,
                               TotalAmount = shop.TotalAmount,
                               Description = shop.Description,
                               ShoppingDate = shop.ShoppingDate
                           }).ToList();

            return results;
        }

        // GET: api/ShoppingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingDetail>> GetShoppingDetail(int id)
        {
          if (_context.ShoppingDetails == null)
          {
              return NotFound();
          }
            var shoppingDetail = await _context.ShoppingDetails.FindAsync(id);

            if (shoppingDetail == null)
            {
                return NotFound();
            }

            return shoppingDetail;
        }

        // PUT: api/ShoppingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetail(int id, ShoppingDetail shoppingDetail)
        {
            if (id != shoppingDetail.ShopId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailExists(id))
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

        // POST: api/ShoppingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingDetail>> PostShoppingDetail(ShoppingDetail shoppingDetail)
        {
          if (_context.ShoppingDetails == null)
          {
              return Problem("Entity set 'ShoppingDBContext.ShoppingDetails'  is null.");
          }
            _context.ShoppingDetails.Add(shoppingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingDetail", new { id = shoppingDetail.ShopId }, shoppingDetail);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingDetail(int id)
        {
            if (_context.ShoppingDetails == null)
            {
                return NotFound();
            }
            var shoppingDetail = await _context.ShoppingDetails.FindAsync(id);
            if (shoppingDetail == null)
            {
                return NotFound();
            }

            _context.ShoppingDetails.Remove(shoppingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingDetailExists(int id)
        {
            return (_context.ShoppingDetails?.Any(e => e.ShopId == id)).GetValueOrDefault();
        }
    }
}
