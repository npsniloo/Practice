using System;
using System.Collections.Generic;

namespace BlazorAspCore.Shared.Entities;

public partial class ShoppingDetail
{
    public int ShopId { get; set; }

    public int? ItemId { get; set; }

    public string UserName { get; set; } = null!;

    public int Qty { get; set; }

    public int? TotalAmount { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? ShoppingDate { get; set; }
}
