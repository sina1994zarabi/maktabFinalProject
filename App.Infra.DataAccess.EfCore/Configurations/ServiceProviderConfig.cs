using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
	public class ServiceProviderConfig : IEntityTypeConfiguration<ServiceProvider>
	{
		public void Configure(EntityTypeBuilder<ServiceProvider> builder)
		{
			builder.HasMany(p => p.Services)
			.WithOne(s => s.ServiceProvider)
			.HasForeignKey(s => s.ServiceProviderId)
			.OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
				new ServiceProvider
				{
					Id = 1,
					Username = "ServiceProvider1Username",
					Email = "ServiceProvider1Email@gmail.com",
					FullName = "نام و نام خانوادگی کارشناس یک",
					PhoneNumber = "09xxxxxxxxx",
					Address = "آدرس کارشناس یک",
					DateRegistered = DateTime.UtcNow,
					IsApproved = true
				},
				new ServiceProvider
				{
					Id = 2,
					Username = "ServiceProvider2Username",
					Email = "ServiceProvider2Email@gmail.com",
					FullName = "نام و نام خانوادگی کارشناس دو",
					PhoneNumber = "09yyyyyyyyy",
					Address = "آدرس کارشناس دو",
					DateRegistered = DateTime.UtcNow,
					IsApproved = true
				}
				);
		}
	}
}
