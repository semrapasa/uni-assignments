using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SinemaSalonu.Models;

namespace SinemaSalonu.Controllers
{
    public class AccountController : Controller
    {
        private SinemaContext db = new SinemaContext();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    // Store role in session or retrieve it later. For simple role management, we can rely on DB lookup or custom principal.
                    // For now, simple redirect.
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                }
            }
            return View();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Check if user exists
                if (db.Users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı zaten alınmış.");
                    return View(model);
                }

                model.Role = "User"; // Default role
                db.Users.Add(model);
                db.SaveChanges();

                // Auto login after register
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
