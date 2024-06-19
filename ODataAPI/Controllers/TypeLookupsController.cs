﻿using Core.Entities.Concrete.ProcessGroups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class TypeLookupsController : BaseODataController<TypeLookup, int>
    {
        public TypeLookupsController(DbContext context) : base(context)
        {
        }
    }
}
