using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Shopping()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Items()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Categories()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}