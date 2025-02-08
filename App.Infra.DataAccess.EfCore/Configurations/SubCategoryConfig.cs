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
	public class SubCategoryConfig : IEntityTypeConfiguration<Subcategory>
	{
		public void Configure(EntityTypeBuilder<Subcategory> builder)
		{

			builder.HasOne(sc => sc.Category)
			.WithMany(c => c.Subcategories)
			.HasForeignKey(sc => sc.CategoryId);

			builder.HasData(new Subcategory
			{
				Id = 1,
				Name = "نظافت منزل",
				CategoryId =1
			}
			, new Subcategory
			{   Id = 2,
				Name = "نظافت راه پله",
				CategoryId =1
			}
			);
		}
	}
}
