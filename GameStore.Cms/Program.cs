using Autofac.Core;
using GameStore.Cms;
using GameStore.Cms.Extensions;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.OData;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices();
builder.Services.AddODataServices();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddGlobalIgnore("CreateDate");
    opt.AddGlobalIgnore("EditDate");
}, Assembly.GetExecutingAssembly());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
