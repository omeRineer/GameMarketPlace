using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepositoryAsync<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null,
                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   PaginationParameter? paginationParameter = null,
                                   bool isTracking = true);

        Task<Dictionary<TKey, TValue>> GetDictionariesAsync<TKey, TValue>(Func<TEntity, TKey> key,
                                                                    Func<TEntity, TValue> value,
                                                                    Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                         bool isTracking = true);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task ExecuteSqlAsync(string query, params object[] parameters);

        Task SaveAsync();
    }
}
