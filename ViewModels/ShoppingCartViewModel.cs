using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartSystem.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int ItemId { get; set; }
        public int Quntitay { get; set; }
        public decimal UnitePrice { get; set; }
        public decimal Total { get; set; }
        public string ImagePath { get; set; }
        public string ItemName { get; set; }

    }
}