using System;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;

        public ProductService(IProductRepository productRepository, IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }

        public Task<ProductImage> AddImage(string name, string description,int productId)
        {
           return  _productImageRepository.AddAsync(new ProductImage
            {
                ProductId = productId,
                Name = name,
                Description = description
            });
        }

        public Task<Domain.Models.Product> Create(ProductViewModel input)
        {
            return _productRepository.AddAsync(new Domain.Models.Product
            {
                Name = input.Name,
                Description = input.Description,
                Value=input.Value,
                ProductCategoryId = input.ProductCategoryId
            });
        }

        public Task<ProductQueryResult> GetPaged(int take, int skip, int? categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveImage(string name)
        {
            var productImage = await _productImageRepository.GetProductImageByName(name);
            await _productImageRepository.DeleteAsync(productImage);
        }
    }
}
