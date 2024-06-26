using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Entities.Models.Category.ODataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class CategoriesController : BaseODataController<Category, Guid>
    {
        public CategoriesController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //[HttpPost("Post")]
        //public IActionResult Post([FromBody] CategoryCreateODataModel model) => base.Post(model);
        //[HttpPut] 
        //public IActionResult Put([FromBody] CategoryUpdateODataModel model) => Ok();
        //[HttpDelete] 
        //public IActionResult Delete([FromBody] CategoryCreateODataModel model) => base.Post(model);
    }
}
