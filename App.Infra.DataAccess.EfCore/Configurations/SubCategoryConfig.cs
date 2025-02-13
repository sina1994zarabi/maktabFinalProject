using App.Domain.Core.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
	{
		public void Configure(EntityTypeBuilder<SubCategory> builder)
		{

			builder.HasOne(sc => sc.Category)
			.WithMany(c => c.Subcategories)
			.HasForeignKey(sc => sc.CategoryId);

			builder.HasMany(sc => sc.Services)
				   .WithOne(s => s.Subcategory)
				   .HasForeignKey(sc => sc.SubCategoryId);

			builder.HasData(new SubCategory
			{
				Id = 1,
				Title = "نظافت منزل",
				CategoryId =1
			}
			, new SubCategory
			{   Id = 2,
				Title = "نظافت راه پله",
				CategoryId =1
			}
			);
		}
	}
}
