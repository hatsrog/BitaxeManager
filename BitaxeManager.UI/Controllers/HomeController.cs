using BitaxeManager.Core.data;
using BitaxeManager.UI.Models;
using BitaxeManager.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitaxeManager.UI.Controllers
{
    public class HomeController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var lastLogs = new BitaxeStatsService(context.DeviceStatusLogs).GetLastStats();

            return View(new IndexViewModel { DeviceStatusLogs = lastLogs });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
