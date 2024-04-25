using Application.Product.CreateProduct;
using Application.Product.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Domain.Entities.Product> _productRepository;

        public ProductController(IGenericRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("[action]")]
        public IActionResult AddNewProduct([FromBody] AddProductDto input)
        {
            var createProductCommand = new CreateProductCommand(_productRepository);
            return Ok(createProductCommand.AddNewProduct(input));
        }
    }
}
