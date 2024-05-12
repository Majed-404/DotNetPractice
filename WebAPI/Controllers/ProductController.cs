using Application.Product.CreateProduct;
using Application.Product.Dto;
using Application.Services;
using Infrastructure.Migrations;
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

        [HttpGet]
        public async Task<JsonResult> GetAll() => new JsonResult(Ok( await _productRepository.GetAll()));


        [HttpGet("{id}")]
        public async Task<JsonResult> GetProductById(int id) => new JsonResult(Ok( await _productRepository.GetById(id)));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] AddProductDto model)
        {
            if (id == 0)
                return BadRequest();

            var createProductCommand = new CreateProductCommand(_productRepository);
            var producData = await createProductCommand.GetProductById(id);
            if (producData is null)
                return NotFound($"Product id {id} is not exists");

            return Ok(createProductCommand.EditProduct(id, model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(id == 0)
                return BadRequest();

            var createProductCommand = new CreateProductCommand(_productRepository);
            var producData = await createProductCommand.GetProductById(id);
            if (producData is null)
                return NotFound($"Product id {id} is not exists");

            return Ok(createProductCommand.DeleteProduct(id));
        }


    }
}
