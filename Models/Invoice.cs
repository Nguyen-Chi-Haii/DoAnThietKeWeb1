using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
