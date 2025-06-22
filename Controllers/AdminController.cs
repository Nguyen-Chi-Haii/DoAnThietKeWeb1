using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnThietKeWeb1.Controllers
{
    public class AdminController : Controller
    {
        private readonly GorocoDatabaseContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IShopRepository _productRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IAboutRepository _aboutRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAdminRepository _adminRepository;
        public AdminController(GorocoDatabaseContext context, IOrderRepository orderRepository, IShopRepository productRepository, IBlogRepository blogRepository, IAboutRepository aboutRepository, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAdminRepository adminRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _blogRepository = blogRepository;
            _aboutRepository = aboutRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _adminRepository = adminRepository;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminIndex()
        {
            var currentYear = DateTime.Now.Year;

            ViewBag.MonthlyProductSold = _adminRepository.GetMonthlyProductSold(currentYear);
            ViewBag.MonthlyRevenue = _adminRepository.GetMonthlyRevenue(currentYear);
            ViewBag.TopProducts = _adminRepository.GetTopProducts(5);
            ViewBag.TotalRevenue = _adminRepository.GetTotalRevenue(currentYear);
            ViewBag.TotalSoldProducts = _adminRepository.GetTotalSoldProducts(currentYear);
            ViewBag.TotalSuccessfulOrders = _adminRepository.GetTotalSuccessfulOrders(currentYear);
            ViewBag.Customers = _adminRepository.GetTotalCustomers();

            return View();
        }


    }
}
