using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportingFoodShop.Models;
using System.Data.Entity;

namespace SportingFoodShop.Controllers
{
    // Стили корзины, логина и пароля. (так лень господи боже)

    public class HomeController : Controller
    {
        public SportingFoodContext db = new SportingFoodContext();

        public ActionResult Index()
        {
            Random rnd = new Random();
            List<Product> recommendedProducts = new List<Product>() { };
            for (int i = 0; i < 4; i++)
            {
                int foo = rnd.Next(1, db.Products.Count() - 1);
                recommendedProducts.Add(db.Products
                    .Include(v => v.Categories)
                    .Include(v => v.AggregateType)
                    .Include(v => v.Image)
                    .Where(v => v.Id == foo)
                    .FirstOrDefault());
            }

            ViewBag.Recommended = recommendedProducts;
            return View(ViewBag.Recommended);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(db.Places);
        }
    }
}