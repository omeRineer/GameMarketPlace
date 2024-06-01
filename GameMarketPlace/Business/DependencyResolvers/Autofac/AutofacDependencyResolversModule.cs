using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Castle.DynamicProxy;
using Configuration;
using Core.Utilities.Interceptor;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacDependencyResolversModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.Register<DbContext>(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<CoreContext>();
                optionsBuilder.UseSqlServer(CoreConfiguration.ConnectionString);
                return new CoreContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly)
            //    .AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions
            //    {
            //        Selector = new InterceptorSelector()
            //    })
            //    .SingleInstance();

        }
    }
}
