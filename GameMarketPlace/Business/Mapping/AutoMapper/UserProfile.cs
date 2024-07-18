using AutoMapper;
using MeArch.Module.Security.Model.UserIdentity;
using Models.Auth.Register;
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
