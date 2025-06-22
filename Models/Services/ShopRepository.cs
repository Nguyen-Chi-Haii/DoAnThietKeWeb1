using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class ShopRepository : IShopRepository
    {
        private readonly GorocoDatabaseContext _context;
        private readonly IShopRepository _shoprepository;
        public ShopRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category == category)
                .ToList();
        }
       
    }
}
