using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinemaSalonu.Models;

namespace SinemaSalonu.Controllers
{
    public class HomeController : Controller
    {
        private SinemaContext db = new SinemaContext();

        public ActionResult Index()
        {
            var movies = db.Movies.OrderByDescending(m => m.ReleaseDate).ToList();
            return View(movies);
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return new HttpStatusCodeResult(400);
            Movie movie = db.Movies.FirstOrDefault(m => m.SeoUrl == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
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
    }
}