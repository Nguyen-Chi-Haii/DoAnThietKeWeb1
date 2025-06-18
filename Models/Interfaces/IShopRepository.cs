namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IShopRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
    }
}
