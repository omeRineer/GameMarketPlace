using GameStore.Cms;
using GameStore.Cms.Services.Master;
using GameStore.Cms.Services.OData;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<CategoryODataService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<GameODataService>();
builder.Services.AddSingleton<GameService>();
builder.Services.AddSingleton<MediaODataService>();
builder.Services.AddSingleton<MediaService>();
builder.Services.AddSingleton<SliderContentODataService>();
builder.Services.AddSingleton<SliderContentService>();
builder.Services.AddSingleton<TypeLookupODataService>();
builder.Services.AddSingleton<MenuODataService>();
builder.Services.AddSingleton<MenuService>();
builder.Services.AddSingleton<BlogODataService>();
builder.Services.AddSingleton<BlogService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
