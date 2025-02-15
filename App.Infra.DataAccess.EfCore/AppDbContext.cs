using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using App.Domain.Core.Enums;
using App.Infra.DataAccess.EfCore.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore
{
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Expert> Experts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Service> Services { get; set; }
		public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceOffering> ServiceOfferings { get; set; }
        public DbSet<Category> Categories { get; set; }
		public DbSet<SubCategory> Subcategories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Status> statuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			//modelBuilder.Entity<AppUser>().ToTable("AspNetUsers");
			//modelBuilder.Entity<IdentityRole<int>>().ToTable("AspNetRoles");
			//modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AspNetUserRoles");
			//modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("AspNetUserClaims");
			//modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins");
			//modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims");
			//modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AspNetUserTokens");

			//// If you have any custom profile entities (like Client, Expert, Admin),
			//// make sure to set their table names too:
			//modelBuilder.Entity<Client>().ToTable("Clients");
			//modelBuilder.Entity<Expert>().ToTable("Experts");
			//modelBuilder.Entity<Admin>().ToTable("Admins");


			UserConfig.Seed(modelBuilder);

			modelBuilder.ApplyConfiguration(new AdminConfig());
			modelBuilder.ApplyConfiguration(new ClientConfig());
			modelBuilder.ApplyConfiguration(new ExpertConfig());
			modelBuilder.ApplyConfiguration(new ServiceRequestConfig());
			modelBuilder.ApplyConfiguration(new CityConfig());
			modelBuilder.ApplyConfiguration(new ServiceConfig());
			modelBuilder.ApplyConfiguration(new CategoryConfig());
			modelBuilder.ApplyConfiguration(new SubCategoryConfig());			
			modelBuilder.ApplyConfiguration(new ReviewConfig());
			modelBuilder.ApplyConfiguration(new ServiceOfferingConfig());

			modelBuilder.ApplyConfiguration(new StatusConfig());
		}
	}
}
