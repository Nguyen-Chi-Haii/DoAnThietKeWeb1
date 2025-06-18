using System;
using System.Collections.Generic;

namespace DoAnThietKeWeb1.Models;

public partial class Favorite
{
    public string FavoriteId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
