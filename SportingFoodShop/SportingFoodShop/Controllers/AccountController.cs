using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SportingFoodShop.Models;

namespace SportingFoodShop.Controllers
{
    public class AccountController : Controller
    {
        public SportingFoodContext db = new SportingFoodContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                user = db.Users.FirstOrDefault(v => v.Email == model.Email && v.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = db.Users.FirstOrDefault(v => v.Email == model.Email);
                if (user == null)
                {
                    db.Users.Add(new User
                    {
                        Email = model.Email,
                        Nickname = model.Nickname,
                        Password = model.Password,
                        RoleId = 2,
                        TotalSpentMoney = 0
                    });
                    db.SaveChanges();
                    user = db.Users.Where(v => v.Email == model.Email && v.Password == model.Password).FirstOrDefault();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такой Email уже зарегистрирован");
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult PersonalProfile()
        {
            var currentUser = db.Users.First(v => v.Email == User.Identity.Name);
            RegisterModel foo = new RegisterModel
            {
                Email = currentUser.Email,
                Nickname = currentUser.Nickname,
                Password = currentUser.Password,
                ConfirmPassword = "",
            };

            FormsAuthentication.SetAuthCookie(currentUser.Email, true);
            return View(foo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public ActionResult PersonalProfile(RegisterModel model)
        {
            User currentUser = db.Users.First(v => v.Email == model.Email);
            currentUser.Nickname = model.Nickname;
            currentUser.Password = model.Password;

            db.Entry(currentUser).State = EntityState.Modified;
            db.SaveChanges();
            FormsAuthentication.SetAuthCookie(model.Email, true);
            return View();
        }
    }
}