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
	public class ReviewConfig : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasOne(r => r.ServiceOffering)
				.WithMany()
				.HasForeignKey(r => r.ServiceOfferingId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(r => r.Client)
				.WithMany()
				.HasForeignKey(r => r.ClientId);


			builder.HasData(
				new Review
				{
					Id = 1,
					ClientId = 1,
					ServiceOfferingId = 1,
					Rating = 4,
					Comment = "خوب بود",
					ReviewDate = DateTime.Now,

				});
		}
	}
}
