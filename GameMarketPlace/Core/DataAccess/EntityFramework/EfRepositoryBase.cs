using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> Table;
        public EfRepositoryBase(DbContext context)
        {
            this._context = context;
            Table = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Deleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (includes != null) query = includes(query);

            return query.FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    PaginationParameter? paginationParameter = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (filter != null) query = query.Where(filter);
            if (includes != null) query = includes(query);
            if (orderBy != null) query = orderBy(query);
            if (paginationParameter != null) query = query.Skip(paginationParameter.Value.Page * paginationParameter.Value.Size).Take(paginationParameter.Value.Size);

            return query.ToList();
        }

        public void Update(TEntity entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Dictionary<TKey, TValue> GetDictionaries<TKey, TValue>(Func<TEntity, TKey> key, Func<TEntity, TValue> value, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Table.AsQueryable();

            if (filter != null) query = query.Where(filter);

            return query.ToDictionary(key, value);
        }
    }
}
