using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.ViewModels;

namespace ShoppingCartSystem.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        ShoppingCartEntities4 dbEntities;
        public ItemController()
        {

            dbEntities = new ShoppingCartEntities4();

        }
        public ActionResult Index()
        {
            ItemViewModel listOfCategories = new ItemViewModel();
            listOfCategories.CategoresList = (from cat in dbEntities.Categories
                                              where cat.IsDeleted == false
                                              select new SelectListItem()
                                              {
                                                  Text = cat.CategoryName,
                                                  Value = cat.CategoryId.ToString(),
                                                  Selected = true
                                              });
            return View(listOfCategories);
        }
        [HttpPost]
        public ActionResult AddItem(ItemViewModel item)
        {
            Item newItem = new Item();
            string NewImage = Guid.NewGuid()+Path.GetExtension(item.Image.FileName);
            item.Image.SaveAs(Server.MapPath("~/Images/"+NewImage));
           
            newItem.ItemPath = "~/Images/" + NewImage;
            newItem.CategoryId = item.CategoryId;
            newItem.ItemCode = item.CodeName;
            newItem.ItemDescription = item.Description;
            newItem.ItemPrice = item.Price;
            newItem.ItemName = item.Name;
            dbEntities.Items.Add(newItem);
            dbEntities.SaveChanges();
             var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.ReceiveMessage(newItem);
            return RedirectToAction("Index");

        }
    }
}