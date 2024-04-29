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
        public JsonResult GetAll()
        {
            var producData = _productRepository.GetAll();
            return new JsonResult(Ok(producData));
        }


        [HttpGet("{id}")]
        public JsonResult GetProductById(int id)
        {
            var producData = _productRepository.GetById(id);
            return new JsonResult(Ok(producData));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] AddProductDto model)
        {
            if (id == 0)
                return BadRequest();

            var producData = _productRepository.GetById(id);
            if (producData is null)
                return NotFound($"Product id {id} is not exists");

            var createProductCommand = new CreateProductCommand(_productRepository);
            return Ok(createProductCommand.EditProduct(id,model));
        }


    }
}
