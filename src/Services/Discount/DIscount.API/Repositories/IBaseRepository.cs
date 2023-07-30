using Discount.API.Models;
using Discount.API.Entities;

namespace Discount.API.Repositories
{
    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<Result> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
