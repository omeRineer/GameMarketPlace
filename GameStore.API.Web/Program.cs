using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.ServiceModules;
using Configuration;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.ServiceTools;
using DataAccess.ServiceModules;
using MeArch.Module.Email.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());

builder.Services.AddServiceModules(new IServiceModule[]
{
    new BusinessServiceModule(),
    new MeArchitectureServiceModule(),
    new RepositoryServiceModule(),
    new MassTransitServiceModule()
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


#region Host Build

var app = builder.Build();

StaticServiceProvider.CreateInstance(app.Services.GetService<IServiceScopeFactory>());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(CoreConfiguration.RootPath)
});

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

