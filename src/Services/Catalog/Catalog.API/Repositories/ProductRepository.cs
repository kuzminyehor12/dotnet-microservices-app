using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Result> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                await _catalogContext.Products.InsertOneAsync(product, null, cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex);
            }
        }

        public async Task<Result> DeleteOneAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            var result = await _catalogContext.Products.DeleteOneAsync(filter, cancellationToken: cancellationToken);
            return Result.Define(result.IsAcknowledged && result.DeletedCount > 0);
        }

        public async Task<Product> FirstAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _catalogContext.Products.Find(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllByFilterAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _catalogContext.Products.Find(expression).ToListAsync(cancellationToken);
        }

        public async Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var result = await _catalogContext.Products.ReplaceOneAsync(filter, replacement: product, cancellationToken: cancellationToken);
            return Result.Define(result.IsAcknowledged && result.ModifiedCount > 0);
        }
    }
}
