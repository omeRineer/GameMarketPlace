using Core.ServiceModules;
using Core.Extensions;
using Entities.Main;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Business.ServiceModules;
using Microsoft.OData.Edm;

#region Edm Models
static IEdmModel GetEdmModel()
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<Category>("Categories");

    return oDataBuilder.GetEdmModel();
}
#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceModules(new IServiceModule[]
{
    new MeArchitectureServiceModule()
});

builder.Services.AddControllers()
                .AddOData(options =>
                {
                    options.EnableQueryFeatures();
                    // options.AddRouteComponents("odata", GetEdmModel());
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
