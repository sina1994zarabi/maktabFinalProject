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
	public class ServiceConfig : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.HasOne(s => s.Subcategory)
			.WithMany(sc => sc.Services)
			.HasForeignKey(s => s.SubCategoryId)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasData( 
			new Service
			{
				Id = 1,
				Title = "عنوان خدمت شماره یک",
				Description = "توضیحات خدمت شماره یک ",
				SubCategoryId = 1,
				ServiceProviderId = 1,
				Price = 1000
			});
		}
	}
}
