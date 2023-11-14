using Microsoft.EntityFrameworkCore;
using Faker;
namespace RestaurantReservation.Db
{
    public class Seeder
    {
        private RestaurantReservationDbContext dbContext=new RestaurantReservationDbContext();
        public Customer customer = new Customer()
        {
            Email = Faker.Internet.Email(),
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            Phone = Faker.Phone.Number()
        };
        public Reservation reservation = new Reservation()
        {
            PartySize = Faker.RandomNumber.Next(),
        };
        public Table table = new Table()
        {
            capacity=Faker.RandomNumber.Next(),
        };
        public Order order = new Order()
        {
            TotalAmount=Faker.RandomNumber.Next(),
            OrderDate=Faker.Identification.DateOfBirth()
        };
        public Restaurant restaurant = new Restaurant()
        {
            Address=Faker.Address.SecondaryAddress(),
            StartTime=TimeSpan.Zero,
            EndTime=TimeSpan.Zero,
            Name=Faker.Company.Name(),
            PhoneNumber=Faker.Phone.Number(),
        };
        public Employee employee = new Employee()
        {
            FirstName=Faker.Name.First(),
            LastName=Faker.Name.Last(),
            Position=Faker.Enum.Random<EmployeePosition>(),
        };
        public MenuItem menuItem = new MenuItem()
        {
            Description=Faker.Company.BS(),
            Name=Faker.Name.Prefix(),
            Price=Faker.RandomNumber.Next(),
        };
        public OrderItem orderItem = new OrderItem()
        {
            Quantity=Faker.RandomNumber.Next()
        };
        public Seeder()
        {
            dbContext.Customers.Add(customer);
            dbContext.Employees.Add(employee);
            dbContext.MenuItems.Add(menuItem);
            dbContext.Tables.Add(table);
            dbContext.Reservations.Add(reservation);
            dbContext.Restaurants.Add(restaurant);
            dbContext.Orders.Add(order);
            dbContext.OrderItems.Add(orderItem);
            customer.Reservations.Add(reservation);
            reservation.Customer = customer;
            reservation.Orders.Add(order);
            reservation.Restaurant = restaurant;
            reservation.Table = table;
            menuItem.OrderItems.Add(orderItem);
            menuItem.Restaurant = restaurant;
            orderItem.Order = order;
            orderItem.Item = menuItem;
            restaurant.Employees.Add(employee);
            restaurant.Tables.Add(table);
            order.Employee = employee;
            dbContext.SaveChanges();
        }
    }
}