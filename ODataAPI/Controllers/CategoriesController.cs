using DataAccess.Concrete.EntityFramework;
using Entities.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ODataAPI.Controllers.Base;

namespace ODataAPI.Controllers
{
    public class CategoriesController : BaseODataController<Category>
    {
        public CategoriesController(DbContext context) : base(context) { }
    }
}
