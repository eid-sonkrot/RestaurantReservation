using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db
{
    public class Seeder
    {
        private DbContext dbContext=new RestaurantReservationDbContext();
        public Seeder()
        {
            Customer customer = new Customer { Email = "213", FirstName = "er", LastName = "ss", Phone = "12" };
            dbContext.Add<Customer>(customer);
            dbContext.SaveChanges();
        }
    }
}
