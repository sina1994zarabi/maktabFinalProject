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
	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasMany(c => c.Subcategories).
			 WithOne(sc => sc.Category).
			 HasForeignKey(sc => sc.CategoryId).
			 OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
				new Category {
					Id = 1,
					Name = "خدمات منزل"}
				);
		}
	}
}
