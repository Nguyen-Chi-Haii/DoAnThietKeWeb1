using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Review
{
    public string ReviewId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? ProductId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Product? Product { get; set; }
}
