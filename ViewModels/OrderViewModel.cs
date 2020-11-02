
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartSystem.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime dateTime { get; set; }
        public string OrderNumber { get; set; }
    }
}