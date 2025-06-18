using Microsoft.AspNetCore.Mvc;

namespace DoAnThietKeWeb1.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ShopIndex()
        {
            return View();
        }
    }
}
