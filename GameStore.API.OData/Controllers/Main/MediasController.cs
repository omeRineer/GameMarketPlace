﻿using AutoMapper;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Main
{
    public class MediasController : BaseODataController<Media, Guid>
    {
        public MediasController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}