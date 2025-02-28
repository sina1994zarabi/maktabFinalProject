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
    public class ServiceOfferingConfig : IEntityTypeConfiguration<ServiceOffering>
	{
		public void Configure(EntityTypeBuilder<ServiceOffering> builder)
		{
			builder.HasOne(so => so.Expert)
				   .WithMany(sp => sp.ServiceOfferings)
			       .HasForeignKey(so => so.ExpertId)
				   .OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(so => so.ServiceRequest)
				   .WithMany(sr => sr.ServiceOfferings)
				   .HasForeignKey(so => so.ServiceRequestId);

			builder.HasData(
				new ServiceOffering
				{
					Id = 1,
					Description = "می توانم این کار را برای شما انجام دهم",
					Status = StatusEnum.PendingClientConfirmation,
					ExpertId = 1,
					ServiceRequestId = 1,
					CreatedAt = DateTime.Now
				},
                new ServiceOffering
                {
                    Id = 2,
                    Description = "می توانم این کار را برای شما انجام دهم",
                    Status = StatusEnum.PendingClientConfirmation,
                    ExpertId = 2,
                    ServiceRequestId = 2,
                    CreatedAt = DateTime.Now
                }
                );
		}
	}
}
