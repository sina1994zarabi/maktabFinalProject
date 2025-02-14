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
	public class AdminConfig : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{



			builder.HasData(
				new Admin {
					Id =1,
					Username = "admin",
					FullName = "adminName",
					Email = "admin@gmail.com",
					PhoneNumber = "1234567890",
					Gender = Gender.male,
					Role = UserRole.Admin
				}
				); ;
		}
	}
}
