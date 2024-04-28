using Application.Product.Dto;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
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
    }
}
