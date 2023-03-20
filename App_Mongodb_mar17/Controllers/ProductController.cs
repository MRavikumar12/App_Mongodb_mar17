using App_Mongodb_mar17.Models;
using App_Mongodb_mar17.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Mongodb_mar17.Controllers
{
    [EnableCors("swagger")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll() =>
            await _productService.GetProducts();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var prod = await _productService.GetProductById(id);
            if (prod is null)
            {
                return NotFound();
            }
            return Ok(prod);
        }

        [HttpGet("{category}")]
        public async Task<ActionResult<Product>>GetName(string category)
        {
            var prod=await _productService.GetByName(category);
            if (prod is null)
            {
                return NotFound();
            }
            return Ok(prod);
        }

        [HttpPost]
        public async Task<ActionResult> AddNew(Product product)
        {
            await _productService.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Update(string id, Product product)
        {
            var prod = await _productService.GetProductById(id);
            if (prod is null)
            {
                return NotFound();
            }
            product.id = prod.id;
            await _productService.UpdateProduct(id, product);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult>DeleteProduct(string id)
        {
            var prod = await _productService.GetProductById(id);
            if(prod is null)
            {
                return NotFound();
            }
            await _productService.DeleteProduct(id);
            return NoContent();
        }

    }
}
