using AutoMapper;
using Core.Entities.Concrete.GeneralSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.API.OData.Controllers.Base;

namespace GameStore.API.OData.Controllers.Main
{
    public class GeneralSettingsController : BaseODataController<GeneralSetting, long>
    {
        public GeneralSettingsController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
