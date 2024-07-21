using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechHub.Models;
using TechHub.Models.Products;

namespace TechHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Dbcontext _context;

        public ProductsController(Dbcontext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        [HttpGet("SearchProduct")]
        public async Task<IEnumerable<Product>> SearchProduct([FromQuery] string query) //returns all products containing the name instead of 1 
        {
            var products = await _context.Product.Where(p => p.ProductName.Contains(query)) // Contains make it possible so i can type fx just iphone instead of typing the fullsname 
        .ToListAsync();
          

            if (products == null || !products.Any())
            {
                return (IEnumerable<Product>)NotFound();
            }

            return products;

        }

        [HttpGet("PopularProducts")]
        public async Task<IEnumerable<Product>> GetPopoularProducts()
        {
            var popularProducts = await _context.Product.Take(3).ToListAsync();

            if (popularProducts == null || popularProducts.Count == 0)
            {
                return (IEnumerable<Product>)NotFound();
            }

            return popularProducts;

        }

        [HttpGet("TrendyProducts")]

        public async Task<IEnumerable<Product>> GetTrendyProducts()
        {
            var trendyProducts=await _context.Product.Take(10).ToListAsync();


            if(trendyProducts == null || !trendyProducts.Any())
            {
                return (IEnumerable<Product>)NotFound();
            }
            return trendyProducts;

        }



    }
}




