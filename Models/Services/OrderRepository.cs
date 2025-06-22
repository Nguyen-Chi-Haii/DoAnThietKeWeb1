using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class OrderRepository:IOrderRepository
    {
        private readonly GorocoDatabaseContext _context;
        public OrderRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _context.Invoices.ToList();
        }
        public IEnumerable<Invoice> CancelInvoice(string invoiceId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
            return _context.Invoices.ToList();
        }
    }
}
