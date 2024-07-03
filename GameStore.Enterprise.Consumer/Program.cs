using Core.ServiceModules;
using Core.Extensions;
using GameStore.Enterprise.Consumer.Modules;
using Configuration;
using Business.ServiceModules;
using DataAccess.ServiceModules;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddServiceModules(new IServiceModule[]
{
    new MeArchitectureServiceModule(),
    new BusinessServiceModule(),
    new RabbitMQServiceModule(),
    new RepositoryServiceModule()
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
