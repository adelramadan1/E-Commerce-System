using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartSystem.ViewModels
{
    public class Shopping
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Imagepath { get; set; }
        public string CategoryName { get; set; }
        //public int Cartsize { get; set; }

    }
    public class ItemDate
    {
        public int ItemId { get; set; }
    }
}