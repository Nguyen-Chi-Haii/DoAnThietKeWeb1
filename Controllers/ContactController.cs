using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactIndex()
        {
            return View();
        }
    }
}
