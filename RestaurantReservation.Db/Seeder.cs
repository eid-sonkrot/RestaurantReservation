using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db
{
    public class Seeder
    {

        public void Seed()
        {
            var context = new RestaurantReservationDbContext();

            if (context.Database.CanConnect())
            {
                // Seed Customers
                var customers = new List<Customer>
                {
                    new Customer { first_name = "Alice", last_name = "Johnson",email="12312",phone="0324432" },
                    new Customer { first_name = "Bob", last_name = "Smith",email="12312",phone="0324432" },
                    new Customer { first_name = "Charlie", last_name = "Brown",email="12312",phone="0324432" },
                    new Customer {first_name = "David", last_name = "Williams", email = "12312", phone = "0324432"},
                    new Customer {first_name = "Eve", last_name = "Davis", email = "12312", phone = "0324432"}
                };
                context.Customers.AddRange(customers);

                // Seed Restaurants
                var restaurants = new List<Restaurant>
                {
                    new Restaurant { name = "Restaurant A", address = "123 Main St.",phone_number="12312312",opening_hours=new OpeningHours(){StartTime=TimeSpan.Zero,EndTime=TimeSpan.Zero} },
                    new Restaurant {name = "Restaurant B", address = "456 Elm St.", phone_number = "12312312", opening_hours = new OpeningHours() { StartTime = TimeSpan.Zero, EndTime = TimeSpan.Zero }},
                    new Restaurant { name = "Restaurant C", address = "789 Oak St." ,phone_number="12312312",opening_hours=new OpeningHours(){StartTime=TimeSpan.Zero,EndTime=TimeSpan.Zero} }
                };
                context.Restaurants.AddRange(restaurants);

                // Seed Tables
                var tables = new List<Table>
                {
                    new Table { capacity = 4, restaurant= restaurants[0] },
                    new Table { capacity = 6, restaurant = restaurants[0] },
                    new Table { capacity = 4, restaurant = restaurants[1] },
                    new Table { capacity = 8, restaurant = restaurants[2] }
                };
                context.Tables.AddRange(tables);
                // Seed Employees
                var employees = new List<Employee>
                {
                  new Employee { first_name = "John", last_name = "Doe", position = EmployeePosition.Intern,restaurant=restaurants[0] },
                  new Employee { first_name = "Jane", last_name = "Smith", position = EmployeePosition.Manager,restaurant= restaurants[0] }
                };
                context.Employees.AddRange(employees);
                // Seed MenuItems
                var menuItems = new List<MenuItem>
                {    
                   new MenuItem { name = "Burger", description = "Delicious burger", price = 9.99,restaurant=restaurants[0] },
                   new MenuItem { name = "Fries", description = "Crispy fries", price = 3.49 , restaurant = restaurants[1]},
                   new MenuItem { name = "Pizza", description = "Tasty pizza", price = 12.99 , restaurant = restaurants[2]}
                };
                context.MenuItems.AddRange(menuItems);
               
                // Seed Reservations
                var reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        reservation_date = DateTime.Now.AddDays(1),
                        party_size = 4,
                        customer = customers[0],
                        restaurant = restaurants[0],
                        table = tables[0]
                    },
                };

                context.Reservations.AddRange(reservations);
                var orders = new List<Order>
                {
                 new Order
                 {
                    order_date = DateTime.Now.AddDays(-7),
                       reservation=reservations[0],
                    employee = employees[0],
                    items = new List<OrderItem>
                    {
                        new OrderItem
                        {

                            item= menuItems[0],
                            quantity = 2,
                        },
                        new OrderItem
                        {
                            item = menuItems[1],
                            quantity = 1
                        }
                    }
                 },
                };

                context.Orders.AddRange(orders);
                try
                {
                    context.SaveChanges();
                }catch(DbUpdateException ex)
                {
                    Log.Error(ex, "Unhandled exception");
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}