using App.Domain.Core.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
	{
		public void Configure(EntityTypeBuilder<Expert> builder)
		{

			builder.HasMany(sp => sp.ServiceOfferings)
				   .WithOne(so => so.Expert);

			builder.HasData(
				new Expert
				{
					Id = 1,
					Username = "ServiceProvider1Username",
					Email = "ServiceProvider1Email@gmail.com",
					FullName = "نام و نام خانوادگی کارشناس یک",
					PhoneNumber = "09xxxxxxxxx",
					AddressId = 2,
					IsApproved = true
				},
				new Expert
				{
					Id = 2,
					Username = "ServiceProvider2Username",
					Email = "ServiceProvider2Email@gmail.com",
					FullName = "نام و نام خانوادگی کارشناس دو",
					PhoneNumber = "09yyyyyyyyy",
					AddressId = 2,
					IsApproved = true
				}
				);
		}
	}
}
