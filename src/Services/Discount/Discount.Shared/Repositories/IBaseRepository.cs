using Discount.DataAccess.Models;
using Discount.DataAccess.Entities;

namespace Discount.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<Result> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
