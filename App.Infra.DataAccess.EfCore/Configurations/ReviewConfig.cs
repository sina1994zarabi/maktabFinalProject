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
				.WithMany(sr => sr.Reviews)
				.HasForeignKey(r => r.ServiceOfferingId);

			builder.HasOne(r => r.Client)
				.WithMany(c => c.Reviews)
				.HasForeignKey(r => r.ClientId);
		}
	}
}
