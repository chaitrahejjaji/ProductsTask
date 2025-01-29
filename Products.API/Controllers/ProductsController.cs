using Microsoft.AspNetCore.Mvc;
using Products.Application.Products;
using Products.Application.Products.Dtos;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto product)
        {
            var id = await productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] Guid id)
        {
            return Ok(await productService.GetByIdAsync(id));
        }

    }
}
