namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Invoice> GetAllInvoices();

        IEnumerable<Invoice> CancelInvoice(string invoiceId);
    }
}
