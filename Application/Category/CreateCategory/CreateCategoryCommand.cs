using Application.Category.Dto;
using Application.Services;
using Domain.Entities;

namespace Application.Category.CreateCategory
{
    public class CreateCategoryCommand
    {
        private readonly IGenericRepository<Domain.Entities.Category> _categoryRepository;
        public CreateCategoryCommand(IGenericRepository<Domain.Entities.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool AddNewCategory(AddCategoryDto model)
        {
            try
            {
                _categoryRepository.Insert(new Domain.Entities.Category
                {
                    NameAr = model.NameAr,
                    NameEn = model.NameEn,
                    IsShowable = model.IsShowable,
                });
                _categoryRepository.Save();
                return true;
            }
            catch (Exception) { throw; }


        }

        public async Task<IEnumerable<Domain.Entities.Category>> GetCategories() => await _categoryRepository.GetAll();

        public async Task<Domain.Entities.Category> GetCategoryById(int id) => await _categoryRepository.GetById(id);


        public async Task<bool> EditCategory(int id, AddCategoryDto input)
        {
            try
            {
                var category = await GetCategoryById(id);
                if(category is null)
                    throw new ArgumentNullException(nameof(category));

                category.NameAr = input.NameAr;
                category.NameEn = input.NameEn;
                category.IsShowable = input.IsShowable;

                _categoryRepository.Update(category);

                _categoryRepository.Save();
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public string DeleteCategory(int id)
        {
            try
            {
                var category = GetCategoryById(id);
                if (category is null)
                    throw new ArgumentNullException(nameof(category));

                _categoryRepository.Delete(id);
                _categoryRepository.Save();
                return "Delete Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

    }
}
