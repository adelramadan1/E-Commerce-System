using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartSystem.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public IEnumerable<SelectListItem> CategoresList { get; set; }

    }
}