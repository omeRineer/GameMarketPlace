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
    public interface IGameRepository : IEntityRepository<Game> 
    { 

    }
    public class GameRepository : EfRepositoryBase<Game>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context)
        {
        }
    }
}
