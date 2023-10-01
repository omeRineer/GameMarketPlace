using Core.DataAccess;
using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using Core.Utilities.ResultTool;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.BaseService
{
    public class EntityBaseService<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> Repository;
        public EntityBaseService(IEntityRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual IResult AddAsync(TEntity entity)
        {
            Repository.Add(entity);
            Repository.Save();

            return new SuccessResult();
        }

        public virtual IResult DeleteAsync(TEntity entity)
        {
            Repository.Delete(entity);
            Repository.Save();

            return new SuccessResult();
        }

        public virtual IDataResult<List<TEntity>> GetListAsync()
        {

            return new SuccessDataResult<List<TEntity>>();
        }

        public virtual IResult UpdateAsync(TEntity entity)
        {
            Repository.Update(entity);
            Repository.Save();

            return new SuccessResult();
        }
    }
}
