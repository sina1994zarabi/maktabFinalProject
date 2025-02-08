using App.Domain.Core.Entities;
using App.Domain.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.EfCore.Configurations
{
	public class BookingConfig : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.HasOne(b => b.Service)
			.WithMany(s => s.Bookings)
			.HasForeignKey(b => b.ServiceId)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(b => b.Client)
			.WithMany(c => c.Bookings)
			.HasForeignKey(b => b.ClientId);

			builder.HasData(
				new Booking
				{
					Id = 1,
					ClientId = 1, 
					ServiceId = 1,      
					BookingDate = DateTime.Now,
					ServiceDate = DateTime.Now.AddDays(2),
					Status = StatusEnum.PendingProviderConfirmation,
					PaymentStatus = PaymentStatus.Unpaid
				}
				);
		}
	}
}
