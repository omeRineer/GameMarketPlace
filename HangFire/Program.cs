using Autofac;
using Autofac.Extensions.DependencyInjection;
using BackgroundJobs.Extensions;
using Business.DependencyResolvers.Autofac;
using Business.ServiceModules;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.ServiceTools;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());


builder.Services.AddServiceModules(new IServiceModule[]
{
    new MeArchitectureServiceModule(),
    new RepositoryServiceModule(),
});

builder.Services.AddControllers();
builder.Services.AddSchedulerJobs();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

StaticServiceProvider.CreateInstance(app.Services.GetService<IServiceScopeFactory>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSchedulerJobs();

app.MapControllers();

app.Run();
