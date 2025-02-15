using App.Domain.Core.Entities.Services;
using App.Domain.Core.Enums;
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

			builder.HasData(
				new ServiceRequest
				{
					Id = 1,
					Title = "نظافت و شتشوی آپارتمان",
					Description = "نضافت حیاط و راه پله",
					ServiceId = 1,
					ClientId = 2,
					Status = StatusEnum.AwaitingOfferReveives,
					BookingDate = DateTime.Now.AddDays(2),
				}
				);
		}
	}
}
