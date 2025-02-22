﻿// <auto-generated />
using Carniceria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Carniceria.Migrations
{
    [DbContext(typeof(CarniceriaContext))]
    [Migration("20240819141727_update-amount")]
    partial class updateamount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Carniceria.Entities.Deborts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("total")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Deborts");
                });

            modelBuilder.Entity("Carniceria.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Carniceria.Entities.Sale", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("idProduct")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("total")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("idProduct");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Carniceria.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            password = "admin",
                            username = "admin"
                        });
                });

            modelBuilder.Entity("Carniceria.Entities.Sale", b =>
                {
                    b.HasOne("Carniceria.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
