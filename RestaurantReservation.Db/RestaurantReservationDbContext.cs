using Microsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}