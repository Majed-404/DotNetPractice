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

    }
}
