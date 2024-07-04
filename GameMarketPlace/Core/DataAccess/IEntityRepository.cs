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
    public interface IEntityRepository<TEntity> : IEntityRepositoryAsync<TEntity>
        where TEntity : class, IEntity, new()
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                             PaginationParameter? paginationParameter = null,
                             bool isTracking = true);

        Dictionary<TKey, TValue> GetDictionaries<TKey, TValue>(Func<TEntity, TKey> key,
                                                               Func<TEntity, TValue> value,
                                                               Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter,
                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                    bool isTracking = true);

        bool IsExist(Expression<Func<TEntity, bool>> expression);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void ExecuteSql(string query, params object[] parameters);

        void Save();

    }


}
