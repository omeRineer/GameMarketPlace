using Core.ServiceModules;
using Core.Extensions;
using GameStore.Enterprise.Consumer.Modules;
using Configuration;
using Business.ServiceModules;
using DataAccess.ServiceModules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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
