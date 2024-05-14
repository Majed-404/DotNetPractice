using Application.Product.Dto;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                    CategoryId = input.categoryId,
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

        public async Task<IEnumerable<Domain.Entities.Product>> Getproducts() => await _productRepository.GetAll();

        public async Task<Domain.Entities.Product> GetProductById(int id) => await _productRepository.GetById(id);

        public async Task<bool> EditProduct(int id , AddProductDto input)
        {
            try
            {
                if (id == 0)
                    return false;
                
                var productData = await GetProductById(id);

                if(productData == null)
                    throw new ArgumentNullException(nameof(productData));

                productData.Description = input.Description;
                productData.NameAr = input.NameAr;
                productData.NameEn = input.NameEn;
                productData.Coast = input.Coast;
                productData.StockQuantity = input.StockQuantity;
                productData.Price = input.Price;
                productData.CategoryId = input.categoryId;
                _productRepository.Update(productData);

                _productRepository.Save();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }


        public string DeleteProduct(int id)
        {
            try
            {
                var productData = GetProductById(id);
                if (productData is null)
                    throw new ArgumentNullException(nameof(productData));

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
