﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petshop.Infra.Common;

#nullable disable

namespace Petshop.Infra.Migrations
{
    [DbContext(typeof(BentiShopContext))]
    partial class BentiShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Petshop.Core.Categories.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "accessory"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "food"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "bath"
                        });
                });

            modelBuilder.Entity("Petshop.Core.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("please enter a address name");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("please enter a city name");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("please enter a country name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("please enter a FullName");

                    b.Property<int>("GiftWrap")
                        .HasColumnType("int");

                    b.Property<int>("PaymentOrderId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentOrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Petshop.Core.Orders.OrderInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("Petshop.Core.Orders.PaymentOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Shipped")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PaymentOrder");
                });

            modelBuilder.Entity("Petshop.Core.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "ghalade",
                            Name = "pro01",
                            Price = 10000000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "ghaza khoshk",
                            Name = "pro02",
                            Price = 200000
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "hole",
                            Name = "pro03",
                            Price = 30000
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "zarf",
                            Name = "pro04",
                            Price = 800000
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "ghaza conserve",
                            Name = "pro05",
                            Price = 30000
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "narm konande",
                            Name = "pro06",
                            Price = 30000
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "kafsh",
                            Name = "pro07",
                            Price = 3000000
                        });
                });

            modelBuilder.Entity("Petshop.Core.Orders.Order", b =>
                {
                    b.HasOne("Petshop.Core.Orders.PaymentOrder", "PaymentOrder")
                        .WithMany()
                        .HasForeignKey("PaymentOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentOrder");
                });

            modelBuilder.Entity("Petshop.Core.Orders.OrderInfo", b =>
                {
                    b.HasOne("Petshop.Core.Orders.Order", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderId");

                    b.HasOne("Petshop.Core.Products.Product", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Petshop.Core.Products.Product", b =>
                {
                    b.HasOne("Petshop.Core.Categories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Petshop.Core.Categories.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Petshop.Core.Orders.Order", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
