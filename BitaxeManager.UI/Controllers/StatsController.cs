using BitaxeManager.Core.data;
using BitaxeManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BitaxeManager.UI.Controllers
{
    public class StatsController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            return View(new StatsViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
