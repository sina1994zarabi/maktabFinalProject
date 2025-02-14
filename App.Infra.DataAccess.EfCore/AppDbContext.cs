using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntity;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using App.Infra.DataAccess.EfCore.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore
{
    public class AppDbContext : DbContext
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Review> Reviews { get; set; }

		public DbSet<Status> statuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientConfig());
			modelBuilder.ApplyConfiguration(new ServiceRequestConfig());
			modelBuilder.ApplyConfiguration(new ExpertConfig());
			modelBuilder.ApplyConfiguration(new AdminConfig());
			modelBuilder.ApplyConfiguration(new AddressConfig());
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
