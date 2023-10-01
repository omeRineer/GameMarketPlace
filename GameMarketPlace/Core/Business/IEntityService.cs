using Core.Entities.Abstract;
using Core.Entities.DTO.Pagination;
using Core.Utilities.ResultTool;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IEntityService<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<IDataResult<List<TEntity>>> GetListAsync();
        Task<IResult> AddAsync(TEntity entity);
        Task<IResult> DeleteAsync(TEntity entity);
        Task<IResult> UpdateAsync(TEntity entity);
    }
}
