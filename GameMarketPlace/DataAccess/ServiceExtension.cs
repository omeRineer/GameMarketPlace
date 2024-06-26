﻿using Core.DataAccess;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ISystemRequirementRepository, SystemRequirementRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<ISliderContentRepository, SliderContentRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBackgroundJobRepository, BackgroundJobRepository>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IUserRoleClaimRepository, UserRoleClaimRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
        }
    }
}
