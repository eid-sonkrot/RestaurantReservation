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
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customer_id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Property<int>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employee_id"));

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id1")
                        .HasColumnType("int");

                    b.HasKey("employee_id");

                    b.HasIndex("restaurant_id1");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Property<int>("item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("item_id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("restaurant_id")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id1")
                        .HasColumnType("int");

                    b.HasKey("item_id");

                    b.HasIndex("restaurant_id1");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"));

                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<int>("employee_id1")
                        .HasColumnType("int");

                    b.Property<DateTime>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("reservation_id")
                        .HasColumnType("int");

                    b.Property<double>("total_amount")
                        .HasColumnType("float");

                    b.HasKey("order_id");

                    b.HasIndex("employee_id1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.Property<int>("order_item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_item_id"));

                    b.Property<int>("item_id")
                        .HasColumnType("int");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("order_id1")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("order_item_id");

                    b.HasIndex("item_id")
                        .IsUnique();

                    b.HasIndex("order_id1");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Property<int>("reservation_id")
                        .HasColumnType("int");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<int>("customer_id1")
                        .HasColumnType("int");

                    b.Property<int>("party_size")
                        .HasColumnType("int");

                    b.Property<DateTime>("reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("restaurant_id")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id1")
                        .HasColumnType("int");

                    b.Property<int>("table_id")
                        .HasColumnType("int");

                    b.Property<int>("table_id1")
                        .HasColumnType("int");

                    b.HasKey("reservation_id");

                    b.HasIndex("customer_id1");

                    b.HasIndex("restaurant_id1");

                    b.HasIndex("table_id1");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Property<int>("restaurant_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("restaurant_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("restaurant_id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Property<int>("table_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("table_id"));

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_id1")
                        .HasColumnType("int");

                    b.HasKey("table_id");

                    b.HasIndex("restaurant_id1");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "restaurant")
                        .WithMany("employees")
                        .HasForeignKey("restaurant_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "restaurant")
                        .WithMany("menuItems")
                        .HasForeignKey("restaurant_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Employee", "employee")
                        .WithMany("orders")
                        .HasForeignKey("employee_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.MenuItem", "item")
                        .WithOne("orderItem")
                        .HasForeignKey("RestaurantReservation.Db.OrderItem", "item_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Order", "order")
                        .WithMany("items")
                        .HasForeignKey("order_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Customer", "customer")
                        .WithMany("Reservations")
                        .HasForeignKey("customer_id1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Order", "orders")
                        .WithOne("reservation")
                        .HasForeignKey("RestaurantReservation.Db.Reservation", "reservation_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Restaurant", "restaurant")
                        .WithMany("reservations")
                        .HasForeignKey("restaurant_id1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Table", "table")
                        .WithMany("Reservations")
                        .HasForeignKey("table_id1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("orders");

                    b.Navigation("restaurant");

                    b.Navigation("table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.OwnsOne("OpeningHours", "opening_hours", b1 =>
                        {
                            b1.Property<int>("restaurant_id")
                                .HasColumnType("int");

                            b1.Property<TimeSpan>("EndTime")
                                .HasColumnType("time")
                                .HasColumnName("EndTime");

                            b1.Property<TimeSpan>("StartTime")
                                .HasColumnType("time")
                                .HasColumnName("StartTime");

                            b1.HasKey("restaurant_id");

                            b1.ToTable("Restaurants");

                            b1.WithOwner()
                                .HasForeignKey("restaurant_id");
                        });

                    b.Navigation("opening_hours")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "restaurant")
                        .WithMany("tables")
                        .HasForeignKey("restaurant_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Navigation("orderItem")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Navigation("items");

                    b.Navigation("reservation")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Navigation("employees");

                    b.Navigation("menuItems");

                    b.Navigation("reservations");

                    b.Navigation("tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
