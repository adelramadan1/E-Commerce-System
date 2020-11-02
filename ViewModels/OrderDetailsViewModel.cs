using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartSystem.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderdetailsId { get; set; }
        public int OrderId { get; set; }
        public int Item { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}