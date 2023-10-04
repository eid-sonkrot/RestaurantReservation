using Microsoft;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<MenuItem>()
                .HasOne(mi => mi.orderItem)
                .WithOne(oi => oi.item)
                .HasForeignKey<OrderItem>(oi => oi.item_id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(e => e.reservation)
                .WithOne(e=>e.orders)
                .HasForeignKey<Reservation>();
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.opening_hours)
                .Property(oh => oh.StartTime)
                .HasColumnName("StartTime"); 
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.opening_hours)
                .Property(oh => oh.EndTime)
                .HasColumnName("EndTime");
            modelBuilder.Entity<Reservation>()
             .HasOne(r => r.customer)
               .WithMany(c => c.Reservations)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.restaurant)
                .WithMany(r => r.reservations)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.table)
                .WithMany(t => t.Reservations)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.customer)
            .WithMany(c => c.Reservations)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.restaurant)
                .WithMany(r => r.reservations)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.table)
                .WithMany(t => t.Reservations)
                .OnDelete(DeleteBehavior.Restrict);
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
        }

        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Restaurant> Restaurants {set;get;}
        public DbSet<MenuItem> MenuItems { set; get; }     
        public DbSet <OrderItem> OrderItems { set; get; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<ReservationView> ReservationViews { get; set; }
        public DbSet<EmployeeRestaurantView> EmployeeRestaurantViews { get; set; }
    }
}