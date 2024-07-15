using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScoutMarket.Models.Product;
using ScoutMarket.Models.Product.DTOs;
using ScoutMarket.Services.Product.Interfaces;

namespace ScoutMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService productService;
            private readonly ILogger<ProductsController> logger;

            public ProductsController(IProductService productService, ILogger<ProductsController> logger)
            {
                this.productService = productService;
                this.logger = logger;
            }

            [HttpGet]
            [Route("/Products")]
            public async Task<IActionResult> GetProducts()
            {
                IEnumerable<Product> result = await productService.GetProductsAsync().ConfigureAwait(false);
                var response = result.Select(s => new ProductDto { Id = s.Id, Name = s.Name, Description = s.Description, Category = s.Category });
                return Ok(response);
            }

            [HttpGet]
            [Route("/Products/{id}")]
            public async Task<IActionResult> GetProduct([FromRoute] int id)
            {
                Product result = await productService.GetProductAsync(id);

                if (result == null)
                {
                    logger.LogError("Resource not found {id}", id);
                    return NotFound();
                }

                return Ok(result);
            }

            [HttpPost]
            [Route("/Products")]
            public async Task<IActionResult> AddProduct([FromBody] Product product)
            {
                if (ModelState.IsValid)
                {
                    //ProductResponse result = await productService.AddProductAsync(product);
                    //return Ok(result);
                }
                return BadRequest(ModelState);
            }

            [HttpPut]
            [Route("/Products")]
            public async Task<IActionResult> EditProduct([FromBody] Product product)
            {
                if (ModelState.IsValid)
                {
                    int result = await productService.EditProductAsync(product);
                    if (result == 0)
                    {
                        logger.LogError("Resource not found {Id}", product.Id);
                        return NotFound(result);
                    }
                    return Ok(result);
                }
                return BadRequest(ModelState);
            }

            [HttpDelete]
            [Route("/Products/{id}")]
            public async Task<IActionResult> DeleteProduct([FromQuery] int id)
            {
                int result = await productService.DeleteProductAsync(id).ConfigureAwait(false);

                if (result == 0)
                {
                    logger.LogError("Resource not found {id}", id);
                    return NotFound(result);
                }

                return Ok(result);
            }
        }
    }
}