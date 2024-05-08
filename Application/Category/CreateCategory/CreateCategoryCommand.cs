using Application.Category.Dto;
using Application.Services;

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

        public IEnumerable<Domain.Entities.Category> GetCategories() => _categoryRepository.GetAll();

        public Domain.Entities.Category GetCategoryById(int id) => _categoryRepository.GetById(id);


        public bool EditCategory(int id, AddCategoryDto input)
        {
            try
            {
                Domain.Entities.Category category = new Domain.Entities.Category();
                category.Id = id;
                category.NameAr = input.NameAr;
                category.NameEn = input.NameEn;
                category.IsShowable = input.IsShowable;

                _categoryRepository.Update(category);

                _categoryRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteCategory(int id)
        {
            try
            {
                //var productData = _productRepository.GetById(id);
                //if (productData is null)
                //    return $"Product id {id} is not exists";

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
