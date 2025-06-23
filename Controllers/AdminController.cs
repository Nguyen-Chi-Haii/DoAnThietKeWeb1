using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using DoAnThietKeWeb1.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            _aboutRepository =aboutRepository;
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageProducts()
        {
            var products = _productRepository.GetAllProducts().ToList();
            ViewBag.TotalProducts = products.Count;
            return View(products);
        }
        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            _productRepository.DeleteProduct(id);
            return RedirectToAction("ManageProducts");
        }
        [HttpGet]
        public IActionResult EditProduct(string id)
        {
            var product = _productRepository.GetAllProducts().FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(product);
                return RedirectToAction("ManageProducts");

            }
            return View(product);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories = _context.Products
           .Where(p => !string.IsNullOrEmpty(p.Category))
           .Select(p => p.Category)
           .Distinct()
           .ToList();

            ViewBag.ExistingCategories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                 _productRepository.AddProduct(product);
                return RedirectToAction("ManageProducts");
            }

            // 🐞 Gỡ lỗi: in ra lỗi ModelState
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("Model Error: " + error.ErrorMessage);
            }

            var categories = _context.Products
                .Where(p => !string.IsNullOrEmpty(p.Category))
                .Select(p => p.Category)
                .Distinct()
                .ToList();

            ViewBag.ExistingCategories = categories;
            return View(product);
        }
        public async Task<IActionResult> ManageOrders(int page = 1)
        {
            int pageSize = 3;

            // Không lọc theo userId, lấy toàn bộ đơn hàng
            var invoices = _orderRepository.GetAllInvoices(); // <-- Thêm hàm này vào repository

            int totalInvoices = invoices.Count();
            int totalPages = (int)Math.Ceiling((double)totalInvoices / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            // Trả về danh sách theo trang
            var pagedInvoices = invoices.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return View(pagedInvoices);
        }
        [HttpGet]
        public IActionResult SortAdminOrderStatus(string status, int page = 1)
        {
            int pageSize = 3;
            var allInvoices = _orderRepository.GetAllInvoices();

            // Đếm số lượng hóa đơn theo trạng thái
            int totalAll = allInvoices.Count();
            int totalPending = allInvoices.Count(i => i.Status == "Đang xử lý");
            int totalConfirmed = allInvoices.Count(i => i.Status == "Đã xác nhận");
            int totalCanceled = allInvoices.Count(i => i.Status == "Đã hủy");

            var filteredInvoices = string.IsNullOrEmpty(status)
                ? allInvoices
                : allInvoices.Where(i => i.Status == status).ToList();

            int count = filteredInvoices.Count();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SelectedStatus = status;

            ViewBag.CountAll = totalAll;
            ViewBag.CountPending = totalPending;
            ViewBag.CountConfirmed = totalConfirmed;
            ViewBag.CountCanceled = totalCanceled;

            var pagedInvoices = filteredInvoices
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return View("~/Views/Admin/ManageOrders.cshtml", pagedInvoices); // <- TRẢ ĐÚNG VIEW
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ManageUsers()
        {
            var users = _adminRepository.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await _adminRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var roles = await _adminRepository.GetUserRolesAsync(user);
            var allRoles = await _adminRepository.GetAllRolesAsync();

            ViewBag.AllRoles = allRoles;
            ViewBag.UserRoles = roles;

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRoles(string userId, List<string> selectedRoles)
        {
            var user = await _adminRepository.GetUserByIdAsync(userId);
            if (user == null) return NotFound();

            await _adminRepository.UpdateUserRolesAsync(user, selectedRoles);
            TempData["Success"] = "Cập nhật vai trò thành công!";
            return RedirectToAction("UserDetails", new { id = userId });
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageGallery()
        {
            var galleries = _aboutRepository.GetGallery();
            return View(galleries);
        }

        [HttpGet]
        public IActionResult GalleryCreate()
        {
            return View("UpdateGallery", new Gallery());
        }

        [HttpPost]
        public IActionResult GalleryCreate(Gallery model)
        {
            if (ModelState.IsValid)
            {
                model.GalleryId = _aboutRepository.GenerateNextGalleryId(); // Tạo ID tự động
                _aboutRepository.Add(model);
                _aboutRepository.Save();
                return RedirectToAction("ManageGallery");
            }

            return View("UpdateGallery", model);
        }

        [HttpGet]
        public IActionResult GalleryEdit(string id)
        {
            var image = _aboutRepository.GetById(id);
            if (image == null) return NotFound();
            return View("UpdateGallery", image);
        }

        [HttpPost]
        public IActionResult GalleryEdit(Gallery model)
        {
            if (ModelState.IsValid)
            {
                _aboutRepository.Update(model);
                _aboutRepository.Save();
                return RedirectToAction("ManageGallery");
            }
            return View("UpdateGallery", model);
        }

        [HttpPost]
        public IActionResult GalleryDelete(string id)
        {
           _aboutRepository.Delete(id);
           _aboutRepository.Save();
            return RedirectToAction("Index");
        }
    }
}

