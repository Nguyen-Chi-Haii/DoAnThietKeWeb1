using System.Diagnostics;
using DoAnThietKeWeb1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult HomeIndex()
        {
            return View();
        }

    }
}
