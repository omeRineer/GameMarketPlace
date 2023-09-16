using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using DataAccess.Concrete.EntityFramework;
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
            //builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            //builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            //builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            //builder.Register(x =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<Context>();
            //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MeArchitecture;Trusted_Connection=True;");
            //    return new Context(optionsBuilder.Options);
            //}).InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new InterceptorSelector()
                })
                .SingleInstance();

        }
    }
}
