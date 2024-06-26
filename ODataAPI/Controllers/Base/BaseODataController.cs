﻿using AutoMapper;
using Core.Entities.Abstract;
using Core.Entities.DTO.Base;
using Core.Utilities.ResultTool.APIResult;
using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace ODataAPI.Controllers.Base
{
    public abstract class BaseODataController<TEntity, TKey> : ODataController
        where TEntity : BaseEntity<TKey>, IEntity, new()
    {
        private readonly IMapper _mapper;
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Table;

        public BaseODataController(DbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
            Table = Context.Set<TEntity>();
        }

        [EnableQuery]
        public IQueryable<TEntity> Get()
        {
            var query = Table.AsQueryable();

            return query;
        }

        [EnableQuery]
        public TEntity Get([FromRoute] TKey key)
        {
            var query = Table.Find(key);

            return query;
        }

        protected IActionResult Post<TODataModel>(TODataModel model)
            where TODataModel : class, IODataModel
        {
            var entity = _mapper.Map<TEntity>(model);

            Table.Add(entity);

            Context.SaveChanges();

            return Ok();
        }

        protected IActionResult Put<TODataModel>(TKey key, TODataModel model)
            where TODataModel : class, IODataModel
        {
            if (!Table.Any(a => a.Id.Equals(key)))
                return NotFound();

            var entity = Table.Single(f => f.Id.Equals(key));
            var modifiedEntity = _mapper.Map(model, entity);

            Table.Update(modifiedEntity);

            Context.SaveChanges();

            return Ok();
        }

        protected IActionResult Delete(TKey key)
        {
            var entity = Table.SingleOrDefault(f => f.Id.Equals(key));

            if (entity == null)
                return NotFound();

            Table.Remove(entity);
            Context.SaveChanges();

            return Ok();
        }
    }
}
