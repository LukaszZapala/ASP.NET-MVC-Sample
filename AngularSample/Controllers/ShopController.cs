using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Sklep.Models;

namespace Sklep.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private ApplicationDbContext context;

        public ShopController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Shop
        public ActionResult Index()
        {
        
            return View();
        }

        public ActionResult GetProducts()
        {
            Thread.Sleep(1500);
            var products = context.Products.ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}