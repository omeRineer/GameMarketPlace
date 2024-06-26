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
    public interface IBackgroundJobRepository : IEntityRepository<BackgroundJob>
    {

    }
    public class BackgroundJobRepository : EfRepositoryBase<BackgroundJob>, IBackgroundJobRepository
    {
        public BackgroundJobRepository(DbContext context) : base(context)
        {
        }
    }
}
