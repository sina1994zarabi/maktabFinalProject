using App.Domain.Core.Entities;
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
		public DbSet<ServiceProvider> ServiceProviders { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Subcategory> Subcategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientConfig());
			modelBuilder.ApplyConfiguration(new ServiceProviderConfig());
			modelBuilder.ApplyConfiguration(new ServiceConfig());
			modelBuilder.ApplyConfiguration(new CategoryConfig());
			modelBuilder.ApplyConfiguration(new SubCategoryConfig());
			modelBuilder.ApplyConfiguration(new BookingConfig());
		}
	}
}
