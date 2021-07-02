using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingFoodShop.Models;

namespace SportingFoodShop.Models.CustomClasses
{
    public class Math
    {
        public static decimal MulResult(int a, decimal b)
        {
            return a * b;
        }

        public static decimal FinalBasketSum(List<LocalBasketElement> lbe)
        {
            decimal sum = 0;
            foreach (var item in lbe)
            {
                sum += (item.Cost * item.Quantity);
            }
            return sum;
        }

        public static decimal CountOrderSum(string key)
        {
            SportingFoodContext db = new SportingFoodContext();
            decimal result = 0;
            foreach (var item in db.ShoppingCarts)
            {
                if (item.PersonalOrderId == key)
                {
                    result += (item.Cost * item.Quantity);
                }
            }
            return result;
        }

        // Времени было мало, пришлось писать херню ниже

        public static List<User> Top3Users(SportingFoodContext db) // Топ3 пользователей, потративших больше всего денег
        {
            List<User> top3users = new List<User>() { };
            List<User> userListCopy = db.Users.ToList();

            for (int i = 0; i < 3; i++)
            {
                User topUser = userListCopy[0];
                foreach (var currentUser in userListCopy)
                {
                    if(currentUser.Orders != null)
                    {
                        if (currentUser.TotalSpentMoney > topUser.TotalSpentMoney)
                        {
                            topUser = currentUser;
                        }
                    }
                }
                top3users.Add(topUser);
                userListCopy.Remove(topUser);
            }
            return top3users;
        }

        public static List<Product> Top3Products(SportingFoodContext db) // Топ3 самых покупаемых товаров
        {
            List<Product> top3products = new List<Product>() { };
            List<Product> productListCopy = db.Products.ToList();

            for (int i = 0; i < 3; i++)
            {
                Product topProduct = productListCopy[0];
                foreach (var currentProduct in productListCopy)
                {
                    //Models.CustomClasses.Math.AllSpentMoneyByUser(currentUser);
                    if (currentProduct.TotalBoughtItems > currentProduct.TotalBoughtItems)
                    {
                        topProduct = currentProduct;
                    }
                }
                top3products.Add(topProduct);
                productListCopy.Remove(topProduct);
            }
            return top3products;
        }
    }

    public class IdGenerator
    {
        private const string chars = "1234567890ABCDEFGHJKLMPQRSTUVWXYZ1234567890";
        public static string GenerateId(int length)
        {
            Random rnd = new Random();
            string foo = "";
            for (int i = 0; i < length; i++)
            {
                foo += chars[rnd.Next(0, chars.Length)];
                System.Threading.Thread.Sleep(rnd.Next(100, 150));
            }
            return foo;
        }
    }

    public class ProductChanged
    {
        public static void ApplyEditions(ref Product target, Product source)
        {
            target.TypeId = source.TypeId;
            target.CategoryId = source.CategoryId;
            target.ImageId = source.ImageId;

            target.Name = source.Name;
            target.Cost = source.Cost;
            target.Weight = source.Weight;
            target.FullDescription = source.FullDescription;
            target.ShortDescription = source.ShortDescription;
        }

        public static void ApplyAdding(ref Product target, SportingFoodContext db)
        {
            //target.Id = db.Products.Last().Id;
            Category cat = db.Categories.Find(target.CategoryId);
            Image img = db.Images.Find(target.ImageId);
            AggregateType type = db.AggregateTypes.Find(target.TypeId);
            target.Categories = cat;
            target.Image = img;
            target.AggregateType = type;
        }
    }
}