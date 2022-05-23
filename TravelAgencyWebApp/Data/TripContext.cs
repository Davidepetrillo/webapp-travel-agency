using Microsoft.EntityFrameworkCore;
using TravelAgencyWebApp.Models;

namespace TravelAgencyWebApp.Data
{
    public class TripContext: DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Database_Trip;Integrated Security=True");
        }
    
    }
}
