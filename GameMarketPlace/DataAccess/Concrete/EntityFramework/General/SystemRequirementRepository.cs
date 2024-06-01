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
    public interface ISystemRequirementRepository : IEntityRepository<SystemRequirement>
    {

    }
    public class SystemRequirementRepository : EfRepositoryBase<SystemRequirement>, ISystemRequirementRepository
    {
        public SystemRequirementRepository(DbContext context) : base(context)
        {
        }
    }
}
