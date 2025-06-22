namespace DoAnThietKeWeb1.Models.Interfaces
{

    public interface IAdminRepository
    {
        Dictionary<int, int> GetMonthlyProductSold(int year);
        Dictionary<int, decimal> GetMonthlyRevenue(int year);
        List<(string ProductName, int TotalQuantity)> GetTopProducts(int top);
        decimal GetTotalRevenue(int year);
        int GetTotalSoldProducts(int year);
        int GetTotalSuccessfulOrders(int year);
        int GetTotalCustomers();
    }
}

