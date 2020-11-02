using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.ViewModels;

namespace ShoppingCartSystem.Controllers
{
    public class CategoryController : Controller
    {
        ShoppingCartEntities4 dbEntities;
        public CategoryController()
        {
            dbEntities = new ShoppingCartEntities4();
        }
        public ActionResult Index()
        {
            IEnumerable<CategoryViewModel> CategoriesList = (from cat in dbEntities.Categories
                              select new CategoryViewModel
                              {
                                  Id = cat.CategoryId,
                                  CodeName = cat.CategoryCode,
                                  Name = cat.CategoryName
                              }).ToList();
            return View(CategoriesList);
        }
    }
}