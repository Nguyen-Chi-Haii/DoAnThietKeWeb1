using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Cart
{
    public string CartId { get; set; } = null!;

    public string? UserId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
