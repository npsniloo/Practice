using System;
using System.Collections.Generic;

namespace BlazorAspCore.Shared.Entities;

public partial class ItemDetail
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int ItemPrice { get; set; }

    public string ImageName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string AddedBy { get; set; } = null!;
}
