using App.Domain.Core.Entities;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
	public class StatusConfig : IEntityTypeConfiguration<Status>
	{
		public void Configure(EntityTypeBuilder<Status> builder)
		{
			builder.HasData(
				new Status { Id = StatusEnum.PendingProviderConfirmation, Name = "در انتظار تایید کارشناس"},
				new Status { Id = StatusEnum.PendingClientConfirmation, Name = "در انتظار تایید مشتری"},
				new Status { Id = StatusEnum.AwaitingOfferReveives, Name = "در انتظار دریافت پیشنهادات"},
				new Status { Id = StatusEnum.Completed, Name = "تایید شده"},
				new Status { Id = StatusEnum.Cancelled, Name = "لغو شده"}

				);
		}
	}
}
