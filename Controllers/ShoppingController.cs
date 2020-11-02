using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.ViewModels;

namespace ShoppingCartSystem.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shoppin
        public  ShoppingCartEntities4 dbEntities;
        public List<ShoppingCartViewModel> CartItems;
        public ShoppingController()
        {
            dbEntities = new ShoppingCartEntities4();
            
        }
          
        public ActionResult Index()
        {
            var itemlist = (from item in dbEntities.Items
                            join cat in dbEntities.Categories
                            on item.CategoryId equals cat.CategoryId
                            select new Shopping
                            {
                                ItemId = item.ItemId,
                                Name = item.ItemName,
                                CategoryName = cat.CategoryName,
                                Description = item.ItemDescription,
                                Price = item.ItemPrice,
                                Imagepath = item.ItemPath,
                                
                            }
                ).ToList();
            return View(itemlist);
        }
        public ActionResult AddToCart(int ItemId)
        {
             CartItems=new List<ShoppingCartViewModel>();
           
            int Counter = 0;
            var item = dbEntities.Items.FirstOrDefault(obj => obj.ItemId == ItemId && obj.IsDeleted != true);
            if(Session["Counter"] !=null)
            {
                CartItems= Session["CartList"] as List<ShoppingCartViewModel>;
            }
            if (CartItems.Any(obj=>obj.ItemId==item.ItemId))
            {
                var ExistItem = CartItems.FirstOrDefault(obj=>obj.ItemId==item.ItemId);
                ExistItem.Quntitay += 1;
                ExistItem.Total = (ExistItem.UnitePrice * ExistItem.UnitePrice);
                
            }
            else
            {

                ShoppingCartViewModel newitem = new ShoppingCartViewModel();
                newitem.ItemId = item.ItemId;
                newitem.Quntitay = 1;
                newitem.UnitePrice = item.ItemPrice;
                newitem.Total = item.ItemPrice;
                newitem.ImagePath = item.ItemPath;
                newitem.ItemName = item.ItemName;
                CartItems.Add(newitem);
            }
            Counter++;
            Session["CartList"] = CartItems;
            Session["Counter"] = Counter;
                return RedirectToAction("Index");

        }
        public ActionResult ShoppingCart()
        {
             CartItems = Session["CartList"] as List<ShoppingCartViewModel>;
            return View(CartItems.ToList());
        }
        public ActionResult AddOrder()
        {
            int orderid = 1;
            int orderdetails =1;
            CartItems = Session["CartList"] as List<ShoppingCartViewModel>;
            OrderDetail orderDetail = new OrderDetail();
            Order order1 = new Order()
            {
                OrderId=orderid,
                OrderDate=DateTime.Now,
                OrderNumber=DateTime.Now+"_"+orderid
            };
          
            dbEntities.Orders.Add(order1);
            dbEntities.SaveChanges();
            foreach(var item in CartItems)
            {
                orderDetail.OrderDetalisId = orderdetails;
                orderDetail.OrderId = orderid;
                orderDetail.ItemId = item.ItemId;
                orderDetail.Quantity = item.Quntitay;
                orderDetail.Total = item.Total;
                orderDetail.Unitprice = item.UnitePrice;
                dbEntities.OrderDetails.Add(orderDetail);
                dbEntities.SaveChanges();
                orderdetails++;
            }
           
            orderid++;
            return RedirectToAction("index");
        }
    }
}