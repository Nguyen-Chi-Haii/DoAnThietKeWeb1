using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class HomeRepository : IHomeRepository
    {
        private readonly GorocoDatabaseContext _context;
        public HomeRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetTrendingProducts()
        {
           
            return _context.Products
                .Where(p => p.Trending == true)
                .Take(3) 
                .ToList();
        }
    }
}
