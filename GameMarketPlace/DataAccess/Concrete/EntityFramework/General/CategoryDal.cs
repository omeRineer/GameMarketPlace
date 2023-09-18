using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

    }
    public class CategoryDal : EfRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(DbContext context) : base(context)
        {
        }
    }
}
