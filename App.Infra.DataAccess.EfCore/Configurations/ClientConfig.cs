using App.Domain.Core.Entities.User;
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
    public class ClientConfig : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{

			builder.HasMany(c => c.ServiceRequests)
				   .WithOne(c => c.Client);


			builder.HasData(
				new Client
				{
					Id = 1,
					FullName = "نام و نام خانوادگی کاربر شماره یک",
					Gender = Gender.male,
					PhoneNumber = "09wwwwwwwwww",
					AppUserId = 2
				},
				new Client
				{
					Id = 2,
					Gender = Gender.male,
					PhoneNumber = "09zzzzzzzzz",
					FullName = "نام و نام خانوادگی کارشناس شماره دو",
					AppUserId = 3
				}
				);
		}
	}
}
