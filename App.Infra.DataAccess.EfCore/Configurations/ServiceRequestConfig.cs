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
    public class ServiceRequestConfig : IEntityTypeConfiguration<ServiceRequest>
	{
		public void Configure(EntityTypeBuilder<ServiceRequest> builder)
		{
			builder.HasOne(sr => sr.Service)
				   .WithMany(s => s.ServiceRequests)
				   .HasForeignKey(sr => sr.ServiceId);

			builder.HasOne(sr => sr.Client)
				   .WithMany(c => c.ServiceRequests)
				   .HasForeignKey(sr => sr.ClientId);
		}
	}
}
