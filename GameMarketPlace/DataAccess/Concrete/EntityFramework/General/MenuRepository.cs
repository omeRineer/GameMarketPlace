using Core.DataAccess.EntityFramework;
using Core.DataAccess;
using Entities.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete.Menu;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IMenuRepository : IEntityRepository<Menu>
    {

    }
    public class MenuRepository : EfRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
        }
    }
}
