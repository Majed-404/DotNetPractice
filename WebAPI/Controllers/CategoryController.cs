using Application.Category.CreateCategory;
using Application.Category.Dto;
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


        [HttpGet("[action]")]
        public async Task<JsonResult> GetAllCategory() => new JsonResult(Ok(await _categoryRepository.GetAll()));


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var createCategoryCommand = new CreateCategoryCommand(_categoryRepository);
            var data = await createCategoryCommand.GetCategoryById(id);
            if (data is null)
                return NotFound($"Category Id {id} is not exists");

            return Ok(data);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] AddCategoryDto category)
        {
            if (id == 0)
                return BadRequest();

            var createCategoryCommand = new CreateCategoryCommand(_categoryRepository);
            var producData = await createCategoryCommand.GetCategoryById(id);
            if (producData is null)
                return NotFound($"Category id {id} is not exists");

            return Ok(createCategoryCommand.EditCategory(id, category));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (id == 0)
                return BadRequest();

            _categoryRepository.Delete(id);
            _categoryRepository.Save();
            return Ok();
        }
    }
}
