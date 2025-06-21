using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public string? UserId { get; set; } = null!;

    public string? CustomerName { get; set; }
    public string? Phone { get; set; }
    public string? DeliveryAddress { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }


    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
