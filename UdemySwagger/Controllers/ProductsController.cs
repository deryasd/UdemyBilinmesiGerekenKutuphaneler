using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemySwagger.Models;

namespace UdemySwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SwaggerDbContext _context;

        public ProductsController(SwaggerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri listeler
        /// </summary>
        /// <remarks>
        /// örnek url https://localhost:7134/api/Products
        /// </remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Bu endpoint id'ye göre ürün getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="404"> verilen ürün bulunamadı</response>
        /// <response code="200"> verilen id'ye sahip ürün var</response>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Bu endpoint id'ye göre ürün günceller
        /// </summary>
        /// <remarks>This method uses optimistic concurrency control. If a concurrency conflict occurs
        /// during the update, the exception is rethrown unless the product does not exist.</remarks>

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

            return NoContent();
        }

        /// <summary>
        /// Bu endpoint yeni ürün ekler
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.Date = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Bu endpoint id'ye göre ürün siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
