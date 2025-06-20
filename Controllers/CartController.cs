using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoAnThietKeWeb1.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartService;

        public CartController(ICartRepository cartService)
        {
            _cartService = cartService;
        }

        // 1. Hiển thị giỏ hàng
        public async Task<IActionResult> CartIndex()
        {
            var cart = await _cartService.GetCartAsync(); // Tự động lấy từ session
            return View(cart);
        }
        [HttpGet]
        public async Task<IActionResult> CartPopup()
        {
            return ViewComponent("Cart");
        }

        // 2. Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, int quantity = 1)
        {
            await _cartService.AddItemToCartAsync(productId, quantity);
            var cart = await _cartService.GetCartAsync();
            return Json(new { success = true });
        }

            // 3. Cập nhật số lượng sản phẩm
            [HttpPost]
        public async Task<IActionResult> UpdateQuantity(string cartItemId, int quantity)
        {
            await _cartService.UpdateItemQuantityAsync(cartItemId, quantity);
            return RedirectToAction("CartIndex");
        }

        // 4. Xoá một sản phẩm khỏi giỏ
        [HttpPost]
        public async Task<IActionResult> RemoveItem(string cartItemId)
        {
            await _cartService.RemoveItemFromCartAsync(cartItemId);
            var cart = await _cartService.GetCartAsync();
            return Json(new { success = true });
        }

        // 5. Xoá toàn bộ giỏ hàng
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCartAsync();
            return RedirectToAction("CartIndex");
        }

        // 6. Thanh toán
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            // Nếu bạn có đăng nhập, thay thế bằng User.Identity.Name hoặc UserID thực tế
            var userId = User.Identity.IsAuthenticated ? User.FindFirst("UserID")?.Value : null;
            await _cartService.CheckoutAsync(userId ?? "anonymous");
            return RedirectToAction("CartIndex");
        }
    }
}
