using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RestaurantReservationCore;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Reservation)
                .HasForeignKey(e => e.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrderItem>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Item)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>()
                .HasOne(e => e.Order)
                .WithOne(e => e.Item)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Table)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Restaurant)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Table>()
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Table)
                .HasForeignKey(e=>e.TableId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Item)
                .WithOne(e => e.Order)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Reservation)
                .WithMany(e => e.Orders)
                .HasForeignKey(e=>e.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Restaurant)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.MenuItems)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Tables)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId).
                OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Item)
                .HasForeignKey(e=>e.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MenuItem>()
                .HasOne(e => e.Restaurant)
                .WithMany(e => e.MenuItems)
                .HasForeignKey(e =>e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .HasConversion(new EnumToStringConverter<EmployeePosition>());
            modelBuilder.Entity<ReservationView>(entity =>
            {
                entity.ToView("ReservationView");
                entity.HasNoKey();
            });
            modelBuilder.Entity<EmployeeRestaurantView>(entity =>
            {
                entity.ToView("EmployeeRestaurantView");
                entity.HasNoKey();
            });
            modelBuilder.HasDbFunction(() => CalculateTotalRevenue(default))
             .HasName("CalculateTotalRevenue");
        }
        [DbFunction(Name = "CalculateTotalRevenue", Schema = "dbo")]
        public  double CalculateTotalRevenue(int restaurantId)
        {
            var totalRevenue = Restaurants
                .Where(r => r.RestaurantId == restaurantId)
                .SelectMany(r => r.Reservations)
                .SelectMany(r => r.Orders)
                .Sum(o=>o.TotalAmount);

            return totalRevenue;
        }
        public async Task<List<Customer>> FindCustomersWithLargePartiesAsync(int minPartySize)
        {
            var minPartySizeParam = new SqlParameter("@minPartySize", minPartySize);

            return await Customers.FromSqlRaw("EXEC FindCustomersWithLargeParties @minPartySize", minPartySizeParam).ToListAsync();
        }
        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Restaurant> Restaurants { set; get; }
        public DbSet<Table> Tables { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}