using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SinemaSalonu.Models;

namespace SinemaSalonu.Controllers
{
    public class BookingController : Controller
    {
        private SinemaContext db = new SinemaContext();

        // GET: Booking/MyBookings
        [Authorize]
        public ActionResult MyBookings()
        {
            var currentUserName = User.Identity.Name;
            var user = db.Users.FirstOrDefault(u => u.Username == currentUserName);
            if (user == null) return RedirectToAction("Login", "Account");

            var bookings = db.Bookings.Include(b => b.Movie).Where(b => b.UserId == user.Id).OrderByDescending(b => b.BookingDate).ToList();
            return View(bookings);
        }

        // POST: Booking/Cancel/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                // Ensure the booking belongs to the logged-in user
                var currentUserName = User.Identity.Name;
                var user = db.Users.FirstOrDefault(u => u.Username == currentUserName);
                
                if (user != null && booking.UserId == user.Id)
                {
                    db.Bookings.Remove(booking);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Biletiniz iptal edildi.";
                }
            }
            return RedirectToAction("MyBookings");
        }

        // POST: Booking/BuyTicket/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult BuyTicket(int movieId)
        {
            var currentUserName = User.Identity.Name;
            var user = db.Users.FirstOrDefault(u => u.Username == currentUserName);
            
            if (user != null)
            {
                Booking booking = new Booking
                {
                    MovieId = movieId,
                    UserId = user.Id,
                    BookingDate = DateTime.Now
                };

                db.Bookings.Add(booking);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Biletiniz başarıyla alındı!";
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Login", "Account");
        }
    }
}
