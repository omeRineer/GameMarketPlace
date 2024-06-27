using AutoMapper;
using Core.Entities.Concrete.GeneralSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers.Main
{
    public class GeneralSettingsController : BaseODataController<GeneralSetting, long>
    {
        public GeneralSettingsController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
