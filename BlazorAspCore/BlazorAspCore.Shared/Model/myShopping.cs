﻿namespace BlazorAspCore.Shared.Model
{
    public class myShopping
    {
        public int ShopId { get; set; }
        public string ItemName { get; set; }
        public string ImageName { get; set; }
        public string UserName { get; set; }
        public int Qty { get; set; }
        public int? TotalAmount { get; set; }
        public string Description { get; set; }
        public DateTime? ShoppingDate { get; set; }
    }
}
