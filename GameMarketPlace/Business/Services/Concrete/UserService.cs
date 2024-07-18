using Business.Services.Abstract;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Security.Model.UserIdentity;
using Microsoft.EntityFrameworkCore;
using Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userDal;
        readonly IUserRoleClaimRepository _userRoleClaimDal;

        public UserService(IUserRepository userDal, IUserRoleClaimRepository userRoleClaimDal)
        {
            _userDal = userDal;
            _userRoleClaimDal = userRoleClaimDal;
        }

        public async Task<IResult> AddAsync(User entity)
        {
            await _userDal.AddAsync(entity);
            await _userDal.SaveAsync();

            return new SuccessResult();
        }

        public Task<IResult> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<User>> GetByLoginModelAsync(UserLoginRequest request)
        {
            var result = await _userDal.GetByUserNameAndPassword(request.UserName, request.Password);

            return result != null ? new SuccessDataResult<User>(result)
                                  : new ErrorDataResult<User>();
        }

        public Task<IDataResult<List<User>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<RoleClaim>>> GetUserRoleClaimsAsync(int userId)
        {
            var userRoleClaims = (await _userRoleClaimDal.GetListAsync(f => f.UserId == userId,
                                                                       i => i.Include(x => x.RoleClaim))).Select(s => s.RoleClaim)
                                                                                                        .ToList();

            return new SuccessDataResult<List<RoleClaim>>(userRoleClaims);
        }

        public async Task<IResult> IsExistByEmailAsync(string email)
        {
            var result = await _userDal.IsExistAsync(e => e.Email == email);

            return result ? new SuccessResult()
                          : new ErrorResult();
        }

        public async Task<IDataResult<bool>> IsExistByLoginModelAsync(UserLoginRequest request)
        {
            var result = await _userDal.IsExistByUserNameAndPassword(request.UserName, request.Password);

            return new SuccessDataResult<bool>(result);
        }

        public async Task<IResult> IsExistByUserNameAsync(string userName)
        {
            var result = await _userDal.IsExistAsync(e => e.UserName == userName);

            return result ? new SuccessResult()
                          : new ErrorResult();
        }

        public Task<IResult> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
