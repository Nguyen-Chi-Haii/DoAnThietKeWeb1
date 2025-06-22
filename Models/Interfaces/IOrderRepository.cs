using Microsoft.EntityFrameworkCore;

namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Invoice> GetPagedInvoices(string userId, int page, int pageSize);
        int GetTotalInvoiceCount(string userId);

        public bool CancelInvoice(string invoiceId);

    }
}
