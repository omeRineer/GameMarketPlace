using Core.Entities.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ODataAPI.Controllers.Base
{
    public class BaseODataController<TEntity, TKey> : ODataController
        where TEntity : class, IEntity, new()
    {
        protected readonly DbContext Context;

        protected BaseODataController(DbContext context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("[controller]")]
        [EnableQuery]
        public IEnumerable<TEntity> GetList()
        {
            var query = Context.Set<TEntity>()
                               .AsQueryable();

            return query;
        }

        //[HttpGet("{key}")]
        //[EnableQuery]
        //public TEntity GetList([FromRoute] TKey key)
        //{
        //    var query = Context.Set<TEntity>()
        //                       .Find(key);

        //    return query;
        //}
    }
}
