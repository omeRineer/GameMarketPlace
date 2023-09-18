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
    public interface IGameDal : IEntityRepository<Game> 
    { 

    }
    public class GameDal : EfRepositoryBase<Game>, IGameDal
    {
        public GameDal(DbContext context) : base(context)
        {
        }
    }
}
