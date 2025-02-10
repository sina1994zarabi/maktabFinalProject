﻿// <auto-generated />
using System;
using App.Infra.DataAccess.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.DataAccess.EfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "نضافت منزل"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "توضیحات خدمت شماره یک ",
                            Price = 1000,
                            SubCategoryId = 1,
                            Title = "عنوان خدمت شماره یک"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceOffering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceProviderId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceProviderId");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("ServiceOffering");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Title = "نظافت منزل"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Title = "نظافت راه پله"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountBalance")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 10000,
                            Address = "آدرس یک",
                            DateRegistered = new DateTime(2025, 2, 10, 18, 56, 30, 67, DateTimeKind.Local).AddTicks(5299),
                            Email = "User1Email@gmail.com",
                            FullName = "نام و نام خانوادگی کاربر یک",
                            Gender = 1,
                            PhoneNumber = "09xxxxxxxxx",
                            Role = 0,
                            Username = "User1Name"
                        },
                        new
                        {
                            Id = 2,
                            AccountBalance = 100000,
                            Address = "آدرس دو",
                            DateRegistered = new DateTime(2025, 2, 10, 18, 56, 30, 67, DateTimeKind.Local).AddTicks(5319),
                            Email = "User2Email@gmail.com",
                            FullName = "نام و نام خانوادگی کاربر دو",
                            Gender = 1,
                            PhoneNumber = "09yyyyyyyy",
                            Role = 0,
                            Username = "User2Name"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.ServiceProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountBalance")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceProviders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 0,
                            Address = "آدرس کارشناس یک",
                            DateRegistered = new DateTime(2025, 2, 10, 15, 26, 30, 68, DateTimeKind.Utc).AddTicks(953),
                            Email = "ServiceProvider1Email@gmail.com",
                            FullName = "نام و نام خانوادگی کارشناس یک",
                            Gender = 0,
                            IsApproved = true,
                            PhoneNumber = "09xxxxxxxxx",
                            Role = 0,
                            Username = "ServiceProvider1Username"
                        },
                        new
                        {
                            Id = 2,
                            AccountBalance = 0,
                            Address = "آدرس کارشناس دو",
                            DateRegistered = new DateTime(2025, 2, 10, 15, 26, 30, 68, DateTimeKind.Utc).AddTicks(959),
                            Email = "ServiceProvider2Email@gmail.com",
                            FullName = "نام و نام خانوادگی کارشناس دو",
                            Gender = 0,
                            IsApproved = true,
                            PhoneNumber = "09yyyyyyyyy",
                            Role = 0,
                            Username = "ServiceProvider2Username"
                        });
                });

            modelBuilder.Entity("ServiceServiceProvider", b =>
                {
                    b.Property<int>("ServiceProvidersId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("ServiceProvidersId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("ServiceServiceProvider");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Service", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Services.Subcategory", "Subcategory")
                        .WithMany("Services")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceOffering", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.ServiceProvider", "ServiceProvider")
                        .WithMany("ServiceOfferings")
                        .HasForeignKey("ServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.ServiceRequest", "ServiceRequest")
                        .WithMany("ServiceOfferings")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceProvider");

                    b.Navigation("ServiceRequest");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceRequest", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.Client", "Client")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.Service", "Service")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Subcategory", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Services.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ServiceServiceProvider", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.ServiceProvider", null)
                        .WithMany()
                        .HasForeignKey("ServiceProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.Service", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Service", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceRequest", b =>
                {
                    b.Navigation("ServiceOfferings");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Subcategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Client", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.ServiceProvider", b =>
                {
                    b.Navigation("ServiceOfferings");
                });
#pragma warning restore 612, 618
        }
    }
}
