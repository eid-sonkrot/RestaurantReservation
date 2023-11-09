﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.HasKey("ItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float")
                        .HasColumnName("total_amount");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_item_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("PartySize")
                        .HasColumnType("int")
                        .HasColumnName("party_size");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("reservation_date");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.Property<int>("TableId")
                        .HasColumnType("int")
                        .HasColumnName("table_id");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("table_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.MenuItem", "Item")
                        .WithMany("OrderItem")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Order", "Order")
                        .WithOne("Item")
                        .HasForeignKey("RestaurantReservation.Db.OrderItem", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
