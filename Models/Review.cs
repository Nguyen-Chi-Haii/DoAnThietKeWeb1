using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnThietKeWeb1.Models;

public partial class Review
{
    public string ReviewId { get; set; } = null!;

    [ForeignKey("UserId")]
    public string? UserId { get; set; } = null!;

    public string? ProductId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Product? Product { get; set; }
    public IdentityUser? User { get; set; }
}
