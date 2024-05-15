using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Dto.Auth.Login;
using MeArch.Module.Security.Model.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class UserService : IUserService
    {
        readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Task<IResult> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<User>> GetByLoginModel(UserLoginRequest request)
        {
            var result = await _userDal.GetByUserNameAndPassword(request.UserName, request.Password);

            return new SuccessDataResult<User>(result);
        }

        public Task<IDataResult<List<User>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<bool>> IsExistByLoginModel(UserLoginRequest request)
        {
            var result = await _userDal.IsExistByUserNameAndPassword(request.UserName, request.Password);

            return new SuccessDataResult<bool>(result);
        }

        public Task<IResult> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
