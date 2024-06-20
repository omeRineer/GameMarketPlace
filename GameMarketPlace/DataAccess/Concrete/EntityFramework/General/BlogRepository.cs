using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IBlogRepository : IEntityRepository<Blog>
    {

    }
    public class BlogRepository : EfRepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        {
        }
    }
}
