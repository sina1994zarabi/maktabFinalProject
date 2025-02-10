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
    public class ServiceOfferingConfig : IEntityTypeConfiguration<ServiceOffering>
	{
		public void Configure(EntityTypeBuilder<ServiceOffering> builder)
		{
			builder.HasOne(so => so.ServiceProvider)
				   .WithMany(sp => sp.ServiceOfferings)
			       .HasForeignKey(so => so.ServiceProviderId);

			builder.HasOne(so => so.ServiceRequest)
				   .WithMany(sr => sr.ServiceOfferings)
				   .HasForeignKey(so => so.ServiceRequestId);

			builder.HasMany(so => so.Reviews)
				   .WithOne(r => r.ServiceOffering);
		}
	}
}
