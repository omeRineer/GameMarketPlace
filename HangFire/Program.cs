using Autofac;
using Autofac.Extensions.DependencyInjection;
using BackgroundJobs.Extensions;
using BackgroundJobs.Modules;
using Business.DependencyResolvers.Autofac;
using Business.ServiceModules;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.ServiceTools;
using DataAccess.ServiceModules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());

builder.Services.AddServiceModules(new IServiceModule[]
{
    new MeArchitectureServiceModule(),
    new RepositoryServiceModule(),
    new BackgroundServicesModule()
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

StaticServiceProvider.CreateInstance(app.Services.GetService<IServiceScopeFactory>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSchedulerJobs();

app.MapControllers();

app.Run();
