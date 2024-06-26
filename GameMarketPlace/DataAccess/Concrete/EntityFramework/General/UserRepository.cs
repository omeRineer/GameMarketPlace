﻿using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public interface IUserRepository : IEntityRepository<User>
    {
        Task<bool> IsExistByUserNameAndPassword(string userName, string password);
        Task<User> GetByUserNameAndPassword(string userName, string password);
    }
    public class UserRepository : EfRepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetByUserNameAndPassword(string userName, string password)
            => await Table.Include(i => i.UserRoleClaims).ThenInclude(i => i.RoleClaim).SingleOrDefaultAsync(f => f.UserName == userName && f.Password == password);

        public async Task<bool> IsExistByUserNameAndPassword(string userName, string password)
            => await Table.AnyAsync(f => f.UserName == userName && f.Password == password);
    }
}
