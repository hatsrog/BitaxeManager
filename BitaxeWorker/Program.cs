using BitaxeManager.Core;
using BitaxeManager.Core.data;
using Coravel;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var apiBaseUrl = builder.Configuration.GetSection("BitaxeAPI:DefaultURL").Value;

builder.Services.AddHttpClient<ApiService>(options =>
    options.BaseAddress = new Uri(apiBaseUrl));
builder.Services.AddScheduler();
builder.Services.AddTransient<BitaxeStatusTask>();

var host = builder.Build();
host.Services.UseScheduler(s =>
{
    s.Schedule<BitaxeStatusTask>().EverySeconds(10);
});
host.Run();
