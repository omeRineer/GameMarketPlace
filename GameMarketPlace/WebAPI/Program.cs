using Business.ServiceModules;
using Core.Extensions;
using Core.ServiceModules;
using MeArch.Module.Email.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceModules(new IServiceModule[]
{
    new BusinessServiceModule(builder.Configuration),
    new MeArchitectureServiceModule()
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Host Build

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

#endregion

