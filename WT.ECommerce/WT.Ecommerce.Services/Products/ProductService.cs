using System;
using System.Linq;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Repositories.Interfaces;
using WT.Ecommerce.Database.Specifications;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IStockRepository _stockRepository;

        public ProductService(IProductRepository productRepository,
                              IProductImageRepository productImageRepository,
                              IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _stockRepository = stockRepository;
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

        public async Task<ProductResponse> Create(ProductRequest input)
        {
            var Product=await _productRepository.AddAsync(new Product
            {
                Name = input.Name,
                Description = input.Description,
                Value=input.Value,
                ProductCategoryId = input.ProductCategoryId
            });

            await _stockRepository.AddAsync(new Stock
            {
                ProductId = Product.Id,
                Qty = input.Qty,
                Description = $"{Product.Name}_Stock"

            });

            return new ProductResponse { Id=Product.Id};
        }

        public async Task<ProductQueryResult> GetPaged(int limit, int skip,string name, int? categoryId)
        {
            var latestProductSpecification = new LatestProductSpecification(name, categoryId, limit, skip);
            var latestProducts = await _productRepository.ListAsync(latestProductSpecification);

            var count = await _productRepository.CountAsync(new LatestProductSpecification(string.Empty, null, null, null));
            return new ProductQueryResult
            {
                results = latestProducts.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryName = p.ProductCategory.Name,
                    Value = p.Value
                }),
                Links = new PaginationLinks("/api/v1/product", count, skip, limit)
            };

        }

        public async Task RemoveImage(string name)
        {
            var productImage = await _productImageRepository.GetProductImageByName(name);
            await _productImageRepository.DeleteAsync(productImage);
        }
    }
}
