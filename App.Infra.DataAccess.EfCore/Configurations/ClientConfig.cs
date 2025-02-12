﻿using App.Domain.Core.Entities.User;
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
					Username = "User1Name",
					FullName = "نام و نام خانوادگی کاربر یک",
					Email = "User1Email@gmail.com",
					Gender = Gender.male,
					PhoneNumber = "09xxxxxxxxx",
					AddressId = 1,
					DateRegistered = DateTime.Now,
					AccountBalance = 10000,
				},
				new Client
				{
					Id = 2,
					Username = "User2Name",
					FullName = "نام و نام خانوادگی کاربر دو",
					Email = "User2Email@gmail.com",
					Gender = Gender.male,
					PhoneNumber = "09yyyyyyyy",
					AddressId = 1,
					DateRegistered = DateTime.Now,
					AccountBalance = 100000
				}
				);
		}
	}
}
