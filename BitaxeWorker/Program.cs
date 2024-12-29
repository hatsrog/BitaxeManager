using BitaxeManager.Core;
using BitaxeManager.Core.data;
using Coravel;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<ApiService>();
builder.Services.AddScheduler();
builder.Services.AddTransient<BitaxeStatusTask>();

var host = builder.Build();
host.Services.UseScheduler(s =>
{
    s.Schedule<BitaxeStatusTask>().EverySeconds(10);
});
host.Run();
