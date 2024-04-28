using Application.Product.Dto;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.CreateCategory
{
    public class CreateCategoryCommand
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public CreateCategoryCommand(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool AddNewCategory(AddCategoryDto model)
        {
            try
            {
                _categoryRepository.Insert(new Category
                {
                    NameAr = model.NameAr,
                    NameEn = model.NameEn,
                    IsShowable = model.IsShowable,
                });
                
                _categoryRepository.Save();
                return true;
            } catch(Exception) { throw; }

           
        }
    }
}
