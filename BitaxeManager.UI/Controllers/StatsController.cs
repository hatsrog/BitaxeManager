using BitaxeManager.Core.data;
using BitaxeManager.UI.Models;
using BitaxeManager.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitaxeManager.UI.Controllers
{
    public class StatsController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var service = new BitaxeStatsService(context.DeviceStatusLogs);
            var averageHashrate = service.GetAverageHashrate();
            service.AverageHashrate(2);
            var averageYesterdayHashrate = service.GetAverageHashrate(DateTime.Today.AddDays(-1));
            return View(new StatsViewModel { AverageHashrate = averageHashrate, AverageYesterdayHashrate = averageYesterdayHashrate });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
