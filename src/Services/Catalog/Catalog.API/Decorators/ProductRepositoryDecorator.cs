using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Models;
using Catalog.API.Repositories;
using System.Linq.Expressions;

namespace Catalog.API.Decorators
{
    public class ProductRepositoryDecorator : IProductRepository
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<ProductRepositoryDecorator> _logger;

        public ProductRepositoryDecorator(
            ICatalogContext catalogContext, 
            ILogger<ProductRepositoryDecorator> logger)
        {
            _productRepository = new ProductRepository(catalogContext);
            _logger = logger;
        }

        public async Task<Result> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.CreateAsync(product, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Product has been created successfully.");
                return result;
            }

            _logger.LogError($"There is while error while creating a product. {result.Exception?.ToString()}");
            return result;
        }

        public async Task<Result> DeleteOneAsync(string id, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteOneAsync(id, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Product has been deleted successfully.");
                return result;
            }

            _logger.LogError($"There is while error while deleting the product. {result.Exception?.ToString()}");
            return result;
        }

        public Task<Product> FirstAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _productRepository.FirstAsync(expression, cancellationToken);
        }

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _productRepository.GetAllAsync(cancellationToken);
        }

        public Task<IEnumerable<Product>> GetAllByFilterAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _productRepository.GetAllByFilterAsync(expression, cancellationToken);
        }

        public async Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var result = await _productRepository.UpdateAsync(product, cancellationToken);

            if (result)
            {
                _logger.LogInformation("Product has been updated successfully.");
                return result;
            }

            _logger.LogError($"There is while error while updating the product. {result.Exception?.ToString()}");
            return result;
        }
    }
}
