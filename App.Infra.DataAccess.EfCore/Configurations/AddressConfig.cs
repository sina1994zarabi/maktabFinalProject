using App.Domain.Core.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
	public class AddressConfig : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{

			builder.HasOne(a => a.City)
				   .WithMany()
				   .HasForeignKey(a => a.CityId);

			builder.HasData(
				new Address
				{
					Id = 1,
					CityId = 1,
					Description = "آدرس فرضی شماره یک",
					PostalCode = "xxxxxxxxxxxxxxxx"
				},
				new Address
				{
					Id = 2,
					CityId = 1,
					Description = "آدرس فرضی شماره دو",
					PostalCode = "yyyyyyyyyyyyyyyy"
				}
				);
		}
	}
}
