using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinemaSalonu.Models
{
    public class SinemaContext : DbContext
    {
        public SinemaContext() : base("name=SinemaConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
