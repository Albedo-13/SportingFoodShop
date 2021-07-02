using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportingFoodShop.Models;
using System.Data.Entity;
using Rotativa;
using System.Web.Security;

namespace SportingFoodShop.Controllers
{
    public class ShopController : Controller
    {
        public SportingFoodContext db = new SportingFoodContext();

        public ActionResult ShopList(string SearchRequest, string CategoryNameFilter)
        {
            IQueryable<Product> filteredItems = db.Products
            .Include(v => v.Image)
            .Include(v => v.AggregateType)
            .Include(v => v.Categories);

            if (SearchRequest != null && SearchRequest != "" && SearchRequest.Length > 1)
            {
                CategoryNameFilter = null;
                filteredItems = filteredItems
                .Where(v => v.Name.ToLower().Contains(SearchRequest.ToLower())
                || v.AggregateType.Name.ToLower().Contains(SearchRequest.ToLower())
                || v.ShortDescription.ToLower().Contains(SearchRequest.ToLower())
                || v.FullDescription.ToLower().Contains(SearchRequest.ToLower())
                || v.Weight.ToString() == SearchRequest);
            }

            if (CategoryNameFilter != null && CategoryNameFilter != "")
            {
                SearchRequest = null;
                filteredItems = filteredItems
                .Where(v => v.Categories.Name.ToLower().Contains(CategoryNameFilter.ToLower()));
            }

            ViewBag.CategoryInit = db.Categories
                .OrderBy(v => v.Name)
                .ToList();
            ViewBag.ProductInit = filteredItems.ToList();

            return View();
        }

        [HttpGet]
        public ActionResult ShowLocalShopList()
        {
            SelectList placesOfAllShops = new SelectList(db.Places, "Id", "Street");    // Добавить номер дома
            ViewBag.PlacesList = placesOfAllShops;

            return View(LocalBasket.Boughts);
        }

        [HttpPost]
        public ActionResult ShowLocalShopList(int ChosenPlaceId)
        {
            if (LocalBasket.Boughts.Count == 0)
            {
                return RedirectToAction("ShopList");
            }

            Place place = db.Places.Find(ChosenPlaceId);
            foreach (var i in LocalBasket.Boughts.ToArray())
            {
                i.Place = place;
            }
            return RedirectToAction("DBShoplist");
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult DBShoplist()
        {
            ShoppingCart order;
            string generateOrderId = Models.CustomClasses.IdGenerator.GenerateId(8);
            foreach (var i in LocalBasket.Boughts.ToArray())
            {
                order = null;
                int fkId = db.Users.Where(v => v.Email == User.Identity.Name).First().Id;
                order = new ShoppingCart
                {
                    Name = i.Name,
                    ShortDescription = i.ShortDescription,
                    FullDescription = i.FullDescription,
                    Cost = i.Cost,
                    Weight = i.Weight,
                    Quantity = i.Quantity,
                    OrderTime = DateTime.Now,
                    ReadyOrderPrediction = DateTime.Now.AddDays(4).ToShortDateString(),
                    State = false,

                    PersonalOrderId = generateOrderId,

                    UserId = fkId,
                    PlaceId = i.Place.Id
                };

                User currentUser = db.Users.Find(fkId);
                currentUser.TotalSpentMoney += (order.Cost * order.Quantity);
                db.Entry(currentUser).State = EntityState.Modified;

                Product currentProduct = db.Products
                .Where(v => v.Name == order.Name
                || v.ShortDescription == order.ShortDescription
                || v.FullDescription == order.FullDescription
                || v.Weight.ToString() == order.Weight)
                .FirstOrDefault();

                currentProduct.TotalBoughtItems += order.Quantity;
                db.Entry(currentProduct).State = EntityState.Modified;

                db.ShoppingCarts.Add(order);
                LocalBasket.Boughts.Remove(i);
            }
            db.SaveChanges();
            Providers.CustomRoleProvider roleProvider = new Providers.CustomRoleProvider();
             IEnumerable<ShoppingCart> myOwnBoughts = null;
            if (roleProvider.IsUserInRole(User.Identity.Name, "User"))
            {
                myOwnBoughts = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place)
                   .Where(v => v.User.Email == User.Identity.Name);
            }
            else if (roleProvider.IsUserInRole(User.Identity.Name, "Admin"))
            {
                myOwnBoughts = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place);
            }

            return View(myOwnBoughts);
        }

        public ActionResult Statistics()
        {
            var top3Users = Models.CustomClasses.Math.Top3Users(db);
            top3Users = top3Users.OrderByDescending(v => v.TotalSpentMoney).ToList();
            ViewBag.Top3Users = top3Users;

            var top3Products = Models.CustomClasses.Math.Top3Products(db);
            top3Products = top3Products.OrderByDescending(v => v.TotalBoughtItems).ToList();
            ViewBag.Top3Products = top3Products;

            return View();
        }

        public ActionResult ChangeState(string PersonalOrderId)
        {
            foreach (var item in db.ShoppingCarts)
            {
                if (item.PersonalOrderId == PersonalOrderId)
                {
                    item.State = true;
                    db.Entry(item).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
            var model = db.ShoppingCarts
                    .Include(u => u.User)
                   .Include(p => p.Place);
            return View("DBShoplist", model);
        }

        public RedirectToRouteResult AddToCart(int Id, string Postfix)
        {
            Product product = db.Products.Find(Id);
            Image img = db.Images.Find(product.ImageId);
            LocalBasketElement lbe = new LocalBasketElement
            {
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                FullDescription = product.FullDescription,
                Cost = product.Cost,
                Weight = $"{product.Weight} {Postfix}",
                Quantity = 1,
                ImagePath = img.ImagePath
            };
            bool IsAlreadyInCart = false;
            foreach (var i in LocalBasket.Boughts.ToArray())
            {
                if (i.Name.Equals(lbe.Name)
                    && i.ShortDescription.Equals(lbe.ShortDescription)
                    && i.Cost.Equals(lbe.Cost)
                    && i.Weight.Equals(lbe.Weight))
                {
                    IsAlreadyInCart = true;
                    i.Quantity += 1;
                    break;
                }
            }
            if (!IsAlreadyInCart) // Добавление
            {
                LocalBasket.Boughts.Add(lbe);
            }
            db.SaveChanges();

            return RedirectToAction("ShopList");
        }

        public ActionResult CheckMyBoughts()
        {
            Providers.CustomRoleProvider roleProvider = new Providers.CustomRoleProvider();
            IEnumerable<ShoppingCart> myOwnBoughts = null;

            if (roleProvider.IsUserInRole(User.Identity.Name, "User"))
            {
                myOwnBoughts = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place)
                   .Where(v => v.User.Email == User.Identity.Name);
            }
            else if (roleProvider.IsUserInRole(User.Identity.Name, "Admin"))
            {
                myOwnBoughts = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place);
            }
            return View("DBShoplist", myOwnBoughts);
        }

        [Authorize(Roles = "Admin, User")]  // Print-only View
        public ActionResult OrdersToPrint()
        {
            Providers.CustomRoleProvider roleProvider = new Providers.CustomRoleProvider();
            IEnumerable<ShoppingCart> arr = null;
            if (roleProvider.IsUserInRole(User.Identity.Name, "User"))
            {
                arr = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place)
                   .Where(v => v.User.Email == User.Identity.Name);
            }
            else if (roleProvider.IsUserInRole(User.Identity.Name, "Admin"))
            {
                arr = db.ShoppingCarts
                   .Include(u => u.User)
                   .Include(p => p.Place);
            }
            return View(arr);
        }

        public ActionResult PrintInvoice()  // Print-only View
        {
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();
            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }

            return new ActionAsPdf("OrdersToPrint")
            { 
                FileName = "FitFood Orders.pdf",
                Cookies = cookieCollection
            };
        }

        [HttpPost]
        // - Кто-то: сколько переменных нужно, чтобы вызвать этот контроллер?
        // - Я: да
        public RedirectToRouteResult EditLocalShopListItems(string action, string Name, string Weight, decimal Cost, int Quantity, string ShortDescription)
        {
            LocalBasketElement lbe = LocalBasket.Boughts.FirstOrDefault(
                v => v.Name == Name &&
                v.Weight == Weight &&
                v.Cost == Cost &&
                v.Quantity == Quantity &&
                v.ShortDescription == ShortDescription);

            if (action == "X")
            {
                if (lbe == null)
                {
                    throw new Exception("not found this bought");
                }

                LocalBasket.Boughts.Remove(lbe);
                return RedirectToAction("ShowLocalShopList");
            }
            if (action == "+1")
            {
                lbe.Quantity += 1;
                return RedirectToAction("ShowLocalShopList");
            }
            if (action == "-1")
            {
                if (lbe.Quantity > 1)
                {
                    lbe.Quantity -= 1;
                }
                return RedirectToAction("ShowLocalShopList");
            }
            throw new Exception("Unknown 'action' value");
        }

        // ADMIN FUNCTIONS

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.ImageList = new SelectList(db.Images, "Id", "ImagePath");
            ViewBag.TypeList = new SelectList(db.AggregateTypes, "Id", "Name");
            ViewBag.CaterogyList = new SelectList(db.Categories, "Id", "Name");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddProduct(Product prod)
        {
            Models.CustomClasses.ProductChanged.ApplyAdding(ref prod, db);
            prod.TotalBoughtItems = 0;

            db.Products.Add(prod);
            db.Entry(prod).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("ShopList");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Product picked = db.Products.Where(v => v.Id == id).FirstOrDefault();
            ViewBag.ImageList = new SelectList(db.Images, "Id", "ImagePath");
            ViewBag.TypeList = new SelectList(db.AggregateTypes, "Id", "Name");
            ViewBag.CaterogyList = new SelectList(db.Categories, "Id", "Name");
            return View(picked);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditProduct(Product prod)
        {
            Product picked = db.Products.Where(v => v.Id == prod.Id)
                .Include(v => v.Image)
                .Include(v => v.AggregateType)
                .Include(v => v.Categories)
                .FirstOrDefault();

            Models.CustomClasses.ProductChanged.ApplyEditions(ref picked, prod);

            db.Entry(picked).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ShopList");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int? id)
        {
            if (id != null)
            {
                Product picked = db.Products.Where(v => v.Id == id).FirstOrDefault();
                db.Products.Remove(picked);
                db.Entry(picked).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return RedirectToAction("ShopList");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var descriptionItem = db.Products
                .Include(v => v.Image)
                .Include(v => v.AggregateType)
                .Include(v => v.Categories)
                .Where(v => v.Id == id)
                .FirstOrDefault();

            var oneProductReviews = db.Reviews
                .Include(v => v.Product)
                .Include(v => v.User);

            ViewBag.ReviewInit = oneProductReviews
                .Where(v => v.ProductId == id)
                .OrderBy(v => v.ReviewDate)
                .ToList();

            return View(descriptionItem);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(int id, string rating, string Title, string Content, string Pluses, string Minuses)
        {
            User currentUser = db.Users.Where(v => v.Email == User.Identity.Name).FirstOrDefault();
            Review newEl = new Review
            {
                ReviewDate = DateTime.Now,
                Stars = Int32.Parse(rating),
                Title = Title,
                Content = Content,
                Pluses = Pluses,
                Minuses = Minuses,
                ProductId = id,
                UserId = currentUser.Id
            }; 
            db.Reviews.Add(newEl);
            db.Entry(newEl).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Details", id);
        }
    }
}