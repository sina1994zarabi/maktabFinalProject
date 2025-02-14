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

            modelBuilder.Entity("App.Domain.Core.Entities.BaseEntity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "آدرس فرضی شماره یک",
                            PostalCode = "xxxxxxxxxxxxxxxx"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "آدرس فرضی شماره دو",
                            PostalCode = "yyyyyyyyyyyyyyyy"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.BaseEntity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "تهران"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceOfferingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceOfferingId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Comment = "خوب بود",
                            Rating = 4,
                            ReviewDate = new DateTime(2025, 2, 14, 13, 54, 24, 203, DateTimeKind.Local).AddTicks(435),
                            ServiceOfferingId = 1
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

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
                            Price = 1000m,
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

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("ServiceOfferings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 14, 13, 54, 24, 203, DateTimeKind.Local).AddTicks(2660),
                            Description = "می توانم این کار را برای شما انجام دهم",
                            ExpertId = 1,
                            ServiceRequestId = 1,
                            Status = 2
                        });
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

                    b.ToTable("ServiceRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingDate = new DateTime(2025, 2, 16, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(7084),
                            ClientId = 1,
                            Description = "نضافت حیاط و راه پله",
                            IsCompleted = false,
                            ServiceId = 1,
                            Status = 1,
                            Title = "نظافت و شتشوی آپارتمان"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("App.Domain.Core.Entities.User.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

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

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 0m,
                            DateRegistered = new DateTime(2025, 2, 14, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(9337),
                            Email = "admin@gmail.com",
                            FullName = "adminName",
                            Gender = 1,
                            PhoneNumber = "1234567890",
                            Role = 2,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

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

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 10000m,
                            AddressId = 1,
                            DateRegistered = new DateTime(2025, 2, 14, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(4284),
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
                            AccountBalance = 100000m,
                            AddressId = 1,
                            DateRegistered = new DateTime(2025, 2, 14, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(4307),
                            Email = "User2Email@gmail.com",
                            FullName = "نام و نام خانوادگی کاربر دو",
                            Gender = 1,
                            PhoneNumber = "09yyyyyyyy",
                            Role = 0,
                            Username = "User2Name"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

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

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Experts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountBalance = 0m,
                            AddressId = 2,
                            DateRegistered = new DateTime(2025, 2, 14, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(8743),
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
                            AccountBalance = 0m,
                            AddressId = 2,
                            DateRegistered = new DateTime(2025, 2, 14, 13, 54, 24, 201, DateTimeKind.Local).AddTicks(8752),
                            Email = "ServiceProvider2Email@gmail.com",
                            FullName = "نام و نام خانوادگی کارشناس دو",
                            Gender = 0,
                            IsApproved = true,
                            PhoneNumber = "09yyyyyyyyy",
                            Role = 0,
                            Username = "ServiceProvider2Username"
                        });
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.Property<int>("ExpertsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("ExpertsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ExpertService");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.BaseEntity.Address", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.BaseEntity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Review", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.ServiceOffering", "ServiceOffering")
                        .WithMany()
                        .HasForeignKey("ServiceOfferingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ServiceOffering");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.Service", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Services.SubCategory", "Subcategory")
                        .WithMany("Services")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Services.ServiceOffering", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.Expert", "Expert")
                        .WithMany("ServiceOfferings")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.ServiceRequest", "ServiceRequest")
                        .WithMany("ServiceOfferings")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

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

            modelBuilder.Entity("App.Domain.Core.Entities.Services.SubCategory", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Services.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Admin", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.BaseEntity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Client", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.BaseEntity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Expert", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.BaseEntity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.User.Expert", null)
                        .WithMany()
                        .HasForeignKey("ExpertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Entities.Services.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
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

            modelBuilder.Entity("App.Domain.Core.Entities.Services.SubCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Client", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.User.Expert", b =>
                {
                    b.Navigation("ServiceOfferings");
                });
#pragma warning restore 612, 618
        }
    }
}
