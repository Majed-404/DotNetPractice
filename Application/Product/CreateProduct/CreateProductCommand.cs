using Application.Product.Dto;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.CreateProduct
{
    public class CreateProductCommand
    {
        private readonly IGenericRepository<Domain.Entities.Product> _productRepository;

        public CreateProductCommand(IGenericRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddNewProduct(AddProductDto input)
        {
            try
            {
                _productRepository.Insert(new Domain.Entities.Product
                {
                    Description = input.Description,
                    NameAr = input.NameAr,
                    NameEn = input.NameEn,
                    Coast = input.Coast,
                    StockQuantity = input.StockQuantity,
                    Price = input.Price,
                    categoryId = input.categoryId,
                    Attachments = new List<ProductAttachment>
                {
                    new ProductAttachment
                    {
                        Path = "majed"
                    },
                    new ProductAttachment
                    {
                        Path = "ahmed"
                    }
                }
                });

                _productRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Domain.Entities.Product> Getproducts() => _productRepository.GetAll();

        public Domain.Entities.Product GetProductById(int id) => _productRepository.GetById(id);

        public bool EditProduct(int id , AddProductDto input)
        {
            try
            {
                if (id == 0)
                    return false;
                
                var productData = _productRepository.GetById(id);

                if(productData == null)
                    return false;

                Domain.Entities.Product product = new Domain.Entities.Product();
                product.Id = id;
                product.Description = input.Description;
                product.NameAr = input.NameAr;
                product.NameEn = input.NameEn;
                product.Coast = input.Coast;
                product.StockQuantity = input.StockQuantity;
                product.Price = input.Price;
                product.categoryId = input.categoryId;

                _productRepository.Update(product);

                _productRepository.Save();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Domain.Entities.Product> GetByName(Expression<Func<Domain.Entities.Product, bool>> match, string[] includes = null)
        {
            return await _productRepository.FindByNameAsync(match, includes);
        }

        public string DeleteProduct(int id)
        {
            try
            {
                //var productData = _productRepository.GetById(id);
                //if (productData is null)
                //    return $"Product id {id} is not exists";

                _productRepository.Delete(id);
                _productRepository.Save();
                return "Delete Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

    }
}
