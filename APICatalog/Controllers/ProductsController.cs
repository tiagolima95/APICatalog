using APICatalog.Context;
using APICatalog.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // api/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
                
        }

        //rota api/produtos/id
        [HttpGet("{id:int}", Name="GetProduct")]
        public async Task<ActionResult<Product>> GetById([FromQuery]int id)
        {
            var product = await _context.Products.AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if(product is null)
            {
                return NotFound("Product not found");
            }

            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
           if(product is null)
           {
                return BadRequest();
           }
            
           _context.Products.Add(product);
           _context.SaveChanges();

           return new CreatedAtRouteResult("GetProduct", 
               new { id = product.ProductId }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product) 
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified; 
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
           var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if(product is null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}
