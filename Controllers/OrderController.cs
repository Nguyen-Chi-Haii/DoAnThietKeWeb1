using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoAnThietKeWeb1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly GorocoDatabaseContext _context;
        public OrderController(IOrderRepository orderRepository, GorocoDatabaseContext context)
        {
            _orderRepository = orderRepository;
            _context = context;
        }
        public IActionResult OrderIndex(int page = 1)
        {
            int pageSize = 3;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var invoices = _orderRepository.GetPagedInvoices(userId, page, pageSize);
            int totalInvoices = _orderRepository.GetTotalInvoiceCount(userId);
            int totalPages = (int)Math.Ceiling((double)totalInvoices / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(invoices);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult CancelInvoice(string invoiceId)
        {
            var result = _orderRepository.CancelInvoice(invoiceId);

            if (result)
            {
                TempData["Success"] = "Đơn hàng đã được hủy.";
            }
            else
            {
                TempData["Error"] = "Không tìm thấy đơn hàng.";
            }

            return RedirectToAction("OrderIndex");
        }

    }
}
