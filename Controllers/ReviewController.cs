using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult ReviewIndex()
        {
            return View();
        }
    }
}
