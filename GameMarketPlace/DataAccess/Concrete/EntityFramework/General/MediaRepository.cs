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
    public interface IMediaRepository : IEntityRepository<Media>
    {

    }
    public class MediaRepository : EfRepositoryBase<Media>, IMediaRepository
    {
        public MediaRepository(DbContext context) : base(context)
        {
        }
    }
}
