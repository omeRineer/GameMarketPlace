using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Entities.Models.Category.ODataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers.Main
{
    public class CategoriesController : BaseODataController<Category, Guid>
    {
        public CategoriesController(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryCreateODataModel model) 
            => base.Post(model);
        [HttpPut]
        public IActionResult Put([FromRoute]Guid key, [FromBody] CategoryUpdateODataModel model) 
            => base.Put(key, model);
        [HttpDelete]
        public IActionResult Delete([FromRoute] Guid key) 
            => base.Delete(key);
    }
}
