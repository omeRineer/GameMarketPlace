using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class CategoriesController : BaseODataController
    {
        protected CategoriesController(CoreContext context) : base(context)
        {
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Category> Get()
        {
            var query = Context.Set<Category>()
                               .AsQueryable();

            return query;
        }
    }
}
