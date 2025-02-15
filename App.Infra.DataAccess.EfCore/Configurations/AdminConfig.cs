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
			builder.HasOne(a => a.AppUser)
				   .WithOne(u => u.AdminProfile)
				   .HasForeignKey<Admin>(a => a.AppUserId)
				   .OnDelete(DeleteBehavior.NoAction);


			builder.HasData(
				new Admin
				{
					Id = 1,
					FullName = "سینا ضرابی",
					Gender = Gender.male,
					AppUserId = 1
				}
				);
		}
	}
}
