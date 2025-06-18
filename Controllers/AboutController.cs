using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult AboutIndex()
        {
            return View();
        }
    }
}
