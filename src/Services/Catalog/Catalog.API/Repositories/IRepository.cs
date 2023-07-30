using Catalog.API.Entities;
using Catalog.API.Models;
using System.Linq.Expressions;

namespace Catalog.API.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<Product>> GetAllByFilterAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken = default);

        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

        Task<Result> CreateAsync(TEntity product, CancellationToken cancellationToken = default);

        Task<Result> UpdateAsync(TEntity product, CancellationToken cancellationToken = default);

        Task<Result> DeleteOneAsync(string id, CancellationToken cancellationToken);
    }
}
