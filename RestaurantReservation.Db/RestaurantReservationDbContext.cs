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
                .HasForeignKey(e => e.CustomerId);
            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Reservation)
                .HasForeignKey(e => e.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Table>()
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Table)
                .HasForeignKey(e=>e.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Item)
                .WithOne(e => e.Order);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.MenuItems)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Tables)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId).
                OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Employees)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.OrderItem)
                .WithOne(e => e.Item)
                .HasForeignKey(e=>e.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .HasConversion(new EnumToStringConverter<EmployeePosition>());
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