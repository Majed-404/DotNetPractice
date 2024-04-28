using Application.Product.CreateCategory;
using Application.Product.Dto;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("[action]")]
        public IActionResult AddCategory([FromBody] AddCategoryDto category)
        {

            var createCategoryCommand = new CreateCategoryCommand(_categoryRepository);
            createCategoryCommand.AddNewCategory(category);

            return Ok(category);
        }
    }
}
