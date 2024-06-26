using Core.ServiceModules;
using Core.Extensions;
using Entities.Main;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Business.ServiceModules;
using Microsoft.OData.Edm;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Entities.Concrete.ProcessGroups;
using Core.Entities.Concrete.Menu;
using System.Text.Json.Serialization;

#region Edm Models
static IEdmModel GetEdmModel()
{
    var oDataBuilder = new ODataConventionModelBuilder();

    oDataBuilder.EntitySet<Category>("Categories");
    oDataBuilder.EntitySet<Game>("Games");
    oDataBuilder.EntitySet<Media>("Medias");
    oDataBuilder.EntitySet<SystemRequirement>("SystemRequirements");
    oDataBuilder.EntitySet<SliderContent>("SliderContents");
    oDataBuilder.EntitySet<TypeLookup>("TypeLookups");
    oDataBuilder.EntitySet<Menu>("Menus");
    oDataBuilder.EntitySet<Blog>("Blogs");

    return oDataBuilder.GetEdmModel();
}
#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());


builder.Services.AddServiceModules(new IServiceModule[]
{
    new MeArchitectureServiceModule()
});

builder.Services.AddControllers()
                .AddOData(options =>
                {
                    options.EnableQueryFeatures();
                    options.AddRouteComponents("odata", GetEdmModel());
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
