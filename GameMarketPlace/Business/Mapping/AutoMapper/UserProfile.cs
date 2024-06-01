using AutoMapper;
using Entities.Dto.Auth.Login;
using Entities.Dto.Auth.Register;
using MeArch.Module.Security.Model.UserIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterRequest, User>();
        }
    }
}
